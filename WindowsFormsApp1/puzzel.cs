using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    class Mypuzzel: Button
    {
        public int i;
        public int j;

        public Mypuzzel Left { get; set; }
        public Mypuzzel Right { get; set; }
        public Mypuzzel Up { get; set; }
        public Mypuzzel Down { get; set; }

    }
}
