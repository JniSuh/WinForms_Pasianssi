using korttipeli.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace korttipeli
{
    public partial class Form1 : Form
    {
        public static Deck deck = new Deck();
        public static List<Col> Columns = new List<Col>();
        List<Card> drawnCards = new List<Card>();
        public static List<Col> aceCol = new List<Col>();

        public static Card cardToMove;
        public static Card targetedCard;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deck.fillDeck(this);

            aceCol.Add(new Col(885, 15, 115, false, true));

            // Luo 8 listaa korttiriveille (ensimmäinen nostetuille korteille)
            Columns.Add(new Col(20, 160, 30, true, false)); // <-- Nostetuille korteille
            for (int i = 160; i <= 760; i += 100)
            {
                Columns.Add(new Col(i, 10, 30, true, true));
            }

            for (int i = 1; i < 8; i++) // Asettaa kortit riveihin
            {
                layCards(this, i, i + 1);
            }
        }

        private void imgDeck_Click(object sender, EventArgs e)
        {
            if (deck.Cards.Count == 1)
            {
                imgDeck.Image = GetImage("Empty");
            }

            if (deck.Cards.Count == 0)
            {
                foreach (Card card in Columns[0].Cards) card.pictureBox.Hide();
                deck.Cards = new List<Card>(Columns[0].Cards);
                Columns[0].Cards.Clear();
                imgDrawnDeck.Hide();
                imgDeck.Image = GetImage("Back");
                return;
            }

            Columns[0].Cards.Add(deck.drawCard()); // Siirtää kortin pakasta nostetuihin kortteihin

            foreach (Card card in Columns[0].Cards)
            {
                card.pictureBox.Enabled = false;
                card.pictureBox.Hide();
            }

            drawnCards.Clear();

            for (int i = 1; i < Columns[0].Cards.Count + 1; i++)
            {
                if (i > 3) break;
                drawnCards.Add(Columns[0].Cards[Columns[0].Cards.Count - i]);
            }

            drawnCards.Reverse();

            int Y = 126;
            foreach (Card card in drawnCards)
            {
                // Luo max 3 uutta nostettua korttia
                card.pictureBox.Location = new Point(20, Y);
                card.pictureBox.Show();
                card.pictureBox.BringToFront();
                Y += 30;
            }
            drawnCards.Last().pictureBox.Enabled = true;

            if (Columns[0].Cards.Count > 3) imgDrawnDeck.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (cardToMove != null) resetSelected();
        }

        private void imgBgCard1_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[1]); }
        private void imgBgCard2_Click(object sender, EventArgs e){ if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[2]); }
        private void imgBgCard3_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[3]); }
        private void imgBgCard4_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[4]); }
        private void imgBgCard5_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[5]); }
        private void imgBgCard6_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[6]); }
        private void imgBgCard7_Click(object sender, EventArgs e) { if (cardToMove != null && targetedCard == null) imgBgCard_Click(Columns[7]); }

        void imgBgCard_Click(Col newCol)
        {
            Col oldCol = null;
            foreach (Col col in Columns)
            {
                if (col.Cards.Contains(cardToMove)) oldCol = col;
            }
            moveCard(cardToMove, newCol, oldCol);
            resetSelected();
        }

        private void imgAceHolder1_Click(object sender, EventArgs e) { AcePlacement(); }
        private void imgAceHolder2_Click(object sender, EventArgs e) { AcePlacement(); }
        private void imgAceHolder3_Click(object sender, EventArgs e) { AcePlacement(); }
        private void imgAceHolder4_Click(object sender, EventArgs e) { AcePlacement(); }

        void AcePlacement()
        {
            if (cardToMove != null && cardToMove.Name.Substring(1) == "1" && targetedCard == null && aceCol[0].Cards.Count != 4 && !aceCol[0].Cards.Contains(cardToMove))
            {
                Col oldCol = null;
                foreach (Col col in Columns)
                {
                    if (col.Cards.Contains(cardToMove)) oldCol = col;
                }
                moveCard(cardToMove, aceCol[0], oldCol);
            }
            resetSelected();
        }

    }
}
