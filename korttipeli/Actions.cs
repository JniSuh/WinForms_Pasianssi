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
            picBox.Image = GetImage(card.Name);
            picBox.Location = new Point(X, Y);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Size = new Size(80, 100);
            picBox.Click += (sender, e) => CardClickEventHandler(sender, e, picBox, form);
            form.Controls.Add(picBox);
            picBox.BringToFront();
            return picBox;
        }

        public static void CardClickEventHandler(object sender, EventArgs e, PictureBox card, Form form)
        {
            if (Form1.cardToMove == null && Form1.cardToMove != card)
            {
                Form1.cardToMove = card;
                Form1.cardToMove.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (Form1.targetedCard == null && Form1.cardToMove != null && Form1.targetedCard != card && Form1.cardToMove != card)
            {
                Form1.targetedCard = card;
                
                if ((Form1.cardToMove.Name[0] == 'S' || Form1.cardToMove.Name[0] == 'C') && (Form1.targetedCard.Name[0] == 'H' || Form1.targetedCard.Name[0] == 'D') && (int.Parse(Form1.targetedCard.Name.Substring(1)) == int.Parse(Form1.cardToMove.Name.Substring(1))+1))
                {
                    int newCol = -1;
                    int oldCol = -1;
                    foreach (Col col in Form1.Columns)
                    {
                        foreach (PictureBox pb in col.Cards)
                        {
                            if (pb.Name == Form1.targetedCard.Name) { newCol = Form1.Columns.IndexOf(col); break; }
                            if (pb.Name == Form1.cardToMove.Name) { oldCol = Form1.Columns.IndexOf(col); break; }

                        }
                        //if (col.Cards.Contains(Form1.targetedCard)) newCol = Form1.Columns.IndexOf(col);
                        //if (col.Cards.Contains(Form1.cardToMove)) oldCol = Form1.Columns.IndexOf(col);
                    }


                    moveCard(Form1.cardToMove, newCol, oldCol, form);
                } else
                {
                    if ((Form1.targetedCard.Name[0] == 'C' || Form1.targetedCard.Name[0] == 'S') && (int.Parse(Form1.targetedCard.Name.Substring(1)) == int.Parse(Form1.cardToMove.Name.Substring(1))+1))
                    {
                        int newCol = -1;
                        int oldCol = -1;
                        foreach (Col col in Form1.Columns)
                        {
                            foreach (PictureBox pb in col.Cards)
                            {
                                if (pb.Name == Form1.targetedCard.Name) { newCol = Form1.Columns.IndexOf(col); break; }
                                if (pb.Name == Form1.cardToMove.Name) { oldCol = Form1.Columns.IndexOf(col); break; }
                            }
                            //if (col.Cards.Contains(Form1.targetedCard)) newCol = Form1.Columns.IndexOf(col);
                            //if (col.Cards.Contains(Form1.cardToMove)) oldCol = Form1.Columns.IndexOf(col);
                        }


                        moveCard(Form1.cardToMove, newCol, oldCol, form);
                    }
                }

                Form1.cardToMove.BorderStyle = BorderStyle.None;
                Form1.cardToMove = Form1.targetedCard = null;
            }
        }

        public static void moveCard(PictureBox cardToMove, int newCol, int oldCol, Form form)
        {
            foreach (Card card in Form1.drawnDeck.Cards)
            {
                if (card.Name == cardToMove.Name) 
                { 
                    Form1.drawnDeck.Cards.Remove(card);
                    moveCard(cardToMove, newCol, oldCol, form);
                    return; 
                }
            }
            foreach (PictureBox picBox in Form1.drawnDeck.Card_objs)
            {
                if (picBox.Name == cardToMove.Name)
                {
                    Form1.drawnDeck.Card_objs.Remove(picBox);
                    picBox.Dispose();
                    moveCard(cardToMove, newCol, oldCol, form);
                    return;
                }
            }

            //if (oldCol >= 0)
            //{
            //    Form1.Columns.RemoveAt(oldCol);
            //}
            if (newCol < 0) newCol = 0;

            if (oldCol >= 0) Form1.Columns[oldCol].Cards.Remove(cardToMove);
            //Form1.Columns[newCol].Y_axis += 30;
            //cardToMove.Location = new Point(Form1.Columns[newCol].X_axis, Form1.Columns[newCol].Y_axis);
            //cardToMove.BringToFront();
            Form1.Columns[newCol].Cards.Add(cardToMove);

            Card newCard = new Card(int.Parse(cardToMove.Name.Substring(1)), cardToMove.Name[0].ToString());
            Form1.Columns[newCol].Y_axis += 30;
            createCard(form, Form1.Columns[newCol].X_axis, Form1.Columns[newCol].Y_axis, newCard);
            //Form1.Columns[newCol].Cards.Add(cardToMove);

            cardToMove.Dispose();
        }

        public static Image GetImage(string imgName) { return (Image)Resources.ResourceManager.GetObject(imgName); }
    }
}
