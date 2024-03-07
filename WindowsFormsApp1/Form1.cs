using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form

    {
        List<Mypuzzel> myPuzzels = new List<Mypuzzel>();
        Mypuzzel[,] states = new Mypuzzel[3, 3];


        public Form1()
        {
            InitializeComponent();
            init();
            shuffle();
        }

        void init()
        {
            foreach (Control control in Controls)
            {
                if (control is Mypuzzel mypuzzel)
                {

                    myPuzzels.Add(mypuzzel);
                }
            }
                int count = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Mypuzzel mypuzzel = myPuzzels[count];
                        mypuzzel.Click += PuzzleButtonClick;
                        states[i, j] = mypuzzel;
                        mypuzzel.i = i;
                        mypuzzel.j = j;
                        count++;
                    }
            }

        }

        void shuffle()
        {
            List<int> stateIndex = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random r = new Random();

            stateIndex = stateIndex.OrderBy(x => r.Next()).ToList();

            for (int i = 0; i < myPuzzels.Count; i++)
            {
                myPuzzels[i].Text = (stateIndex[i] == 9) ? "" : stateIndex[i].ToString();
            }
        }



        void PuzzleButtonClick(object sender, EventArgs e)
        {
            Mypuzzel clickedPuzzle = sender as Mypuzzel;

            int clickedRow = clickedPuzzle.i;
            int clickedCol = clickedPuzzle.j;

            // Check if the adjacent buttons are within the grid boundaries and if they are, swap with them
            if (clickedRow > 0 && states[clickedRow - 1, clickedCol].Text == "") // Up
            {
                swap(clickedPuzzle, states[clickedRow - 1, clickedCol]);
            }
            else if (clickedRow < 2 && states[clickedRow + 1, clickedCol].Text == "") // Down
            {
                swap(clickedPuzzle, states[clickedRow + 1, clickedCol]);
            }
            else if (clickedCol > 0 && states[clickedRow, clickedCol - 1].Text == "") // Left
            {
                swap(clickedPuzzle, states[clickedRow, clickedCol - 1]);
            }
            else if (clickedCol < 2 && states[clickedRow, clickedCol + 1].Text == "") // Right
            {
                swap(clickedPuzzle, states[clickedRow, clickedCol + 1]);
            }
            MessageBox.Show($"You clicked puzzle at position ({clickedPuzzle.i}, {clickedPuzzle.j})");
        }


        void swap(Mypuzzel a, Mypuzzel b)
        {
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = temp;

        }
        bool goal()
        {
            for (int i = 0; i < myPuzzels.Count; i++)
            {
                if (!(i<8 && myPuzzels[i].Text ==(i+1).ToString() || i == 8 && myPuzzels[i].Text ==""))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
