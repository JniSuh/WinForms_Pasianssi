using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using korttipeli.Properties;

namespace korttipeli
{
    class Actions
    {
        public static void layCards(Form form, int col, int incr)
        {
            for (int i = 0; i < incr; i++)
            {
                Card card = Form1.deck.drawCard();
                Form1.Columns[col].Y_axis += 30;
                Form1.Columns[col].Cards.Add(createCard(form, Form1.Columns[col].X_axis, Form1.Columns[col].Y_axis, card));
            }

            foreach (Col column in Form1.Columns)
            {
                for (int i = 0; i < column.Cards.Count - 1; i++)
                {
                    column.Cards[i].Image = GetImage("Back");
                    column.Cards[i].Enabled = false;
                }
            }
        }

        public static PictureBox createCard(Form form, int X, int Y, Card card)
        {
            PictureBox picBox = new PictureBox();
            picBox.Name = card.Name;
            picBox.Image = card.CardPicture;
            picBox.Location = new Point(X, Y);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Size = new Size(88, 100);
            picBox.Click += (sender, e) => CardClickEventHandler(sender, e, picBox);
            form.Controls.Add(picBox);
            picBox.BringToFront();
            return picBox;
        }

        static void CardClickEventHandler(object sender, EventArgs e, PictureBox card)
        {
            if (Form1.cardToMove == null)
            {
                Form1.cardToMove = card;
                card.BorderStyle = BorderStyle.FixedSingle;
                MessageBox.Show("f");
            }
            else if (Form1.targetedCard == null)
            {
                Form1.targetedCard = card;

            }
        }

        public static void displayDrawnCards()
        {

        }

        public static void moveCard()
        {

        }

        public static Image GetImage(string imgName) { return (Image)Resources.ResourceManager.GetObject(imgName); }
    }
}
