using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace korttipeli
{
    public class Col
    {
        public int X_axis;
        public int Y_axis;
        public List<PictureBox> Cards = new List<PictureBox>();

        public Col(int X, int Y)
        {
            X_axis = X;
            Y_axis = Y;
        }
    }
}
