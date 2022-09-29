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
        public int spaceBetween;
        public bool recursive;
        public bool canAddCards;
        public List<Card> Cards = new List<Card>();

        public Col(int X, int Y, int spaceBetweenLevels, bool doRecursive, bool canaddcards)
        {
            X_axis = X;
            Y_axis = Y;
            spaceBetween = spaceBetweenLevels;
            recursive = doRecursive;
            canAddCards = canaddcards;
        }

        public void RenderCol()
        {

        }
    }
}
