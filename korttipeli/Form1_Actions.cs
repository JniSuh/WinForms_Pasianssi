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
    partial class Form1
    {
        public static void layCards(Form form, int col, int incr)
        {
            for (int i = 1; i < incr; i++)
            {
                Card card = deck.drawCard();
                card.pictureBox.Location = new Point(Columns[col].X_axis, Columns[col].Y_axis);
                Columns[col].Y_axis += 30;
                Columns[col].Cards.Add(card);
                card.pictureBox.Show();
                card.pictureBox.BringToFront();
            }

            foreach (Col column in Columns)
            {
                if (column.Cards.Count != 0) column.Cards.Last().pictureBox.Enabled = true;
                for (int i = 0; i < column.Cards.Count - 1; i++)
                {
                    column.Cards[i].pictureBox.Enabled = false;
                    column.Cards[i].pictureBox.Image = GetImage("Back");
                }
            }
        }

        public static PictureBox createCardObj(Form form, Card card)
        {
            PictureBox picBox = new PictureBox();
            picBox.Name = card.Name;
            picBox.Image = GetImage(card.Name);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Size = new Size(80, 100);
            picBox.Click += (sender, e) => CardClickEventHandler(sender, e, card);
            form.Controls.Add(picBox);
            picBox.BringToFront();
            return picBox;
        }

        public static void CardClickEventHandler(object sender, EventArgs e, Card card)
        {
            if (cardToMove == null && cardToMove != card)
            {
                cardToMove = card;
                cardToMove.pictureBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (targetedCard == null && cardToMove != null && targetedCard != card && cardToMove != card)
            {
                targetedCard = card;
                
                if (((cardToMove.Name[0] == 'S' || cardToMove.Name[0] == 'C') && (targetedCard.Name[0] == 'H' || targetedCard.Name[0] == 'D') ||
                    ((cardToMove.Name[0] == 'H' || cardToMove.Name[0] == 'D') && (targetedCard.Name[0] == 'S' || targetedCard.Name[0] == 'C'))) &&
                    (int.Parse(targetedCard.Name.Substring(1)) == int.Parse(cardToMove.Name.Substring(1)) + 1))
                {
                    Col newCol = null;
                    Col oldCol = null;
                    foreach (Col col in Columns)
                    {
                        if (col.Cards.Contains(cardToMove)) oldCol = col;
                        if (col.Cards.Contains(targetedCard)) newCol = col;
                    }
                    if (aceCol[0].Cards.Contains(cardToMove)) oldCol = aceCol[0];


                    moveCard(cardToMove, newCol, oldCol);
                    resetSelected();
                }
            }
        }

        public static void moveCard(Card cardToMove, Col newCol, Col oldCol)
        {
            if (oldCol == newCol) return;
            if (newCol.canAddCards)
            {
                if (oldCol.recursive)
                {
                    for (int i = oldCol.Cards.Count - oldCol.Cards.IndexOf(cardToMove); i > 0; i--)
                    {
                        Card temp = oldCol.Cards[oldCol.Cards.Count - i];
                        oldCol.Cards.Remove(temp);
                        oldCol.Y_axis -= oldCol.spaceBetween;
                        if (oldCol.Cards.Count > 0)
                        {
                            oldCol.Cards.Last().pictureBox.Image = GetImage(oldCol.Cards.Last().Name);
                            oldCol.Cards.Last().pictureBox.Enabled = true;
                        }
                        newCol.Cards.Add(temp);
                        temp.pictureBox.Location = new Point(newCol.X_axis, newCol.Y_axis);
                        newCol.Y_axis += newCol.spaceBetween;
                        temp.pictureBox.BringToFront();
                    }
                }
                else
                {
                    for (int i = aceCol[0].Cards.IndexOf(cardToMove) + 1; i < aceCol[0].Cards.Count; i++)
                    {
                        aceCol[0].Cards[i].pictureBox.Location = new Point(aceCol[0].Cards[i].pictureBox.Location.X, aceCol[0].Cards[i].pictureBox.Location.Y - aceCol[0].spaceBetween);
                    }
                    Card temp = cardToMove;
                    oldCol.Cards.Remove(temp);
                    oldCol.Y_axis -= oldCol.spaceBetween;
                    newCol.Cards.Add(temp);
                    temp.pictureBox.Location = new Point(newCol.X_axis, newCol.Y_axis);
                    newCol.Y_axis += newCol.spaceBetween;
                    temp.pictureBox.BringToFront();
                }
            }
            else resetSelected();
        }

        public static void resetSelected()
        {
            if (cardToMove != null) cardToMove.pictureBox.BorderStyle = BorderStyle.None;
            cardToMove = targetedCard = null;
        }

        public static Image GetImage(string imgName) { return (Image)Resources.ResourceManager.GetObject(imgName); }
    }
}
