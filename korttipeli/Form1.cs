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
        public static Deck drawnDeck = new Deck();
        public static Deck cardsOnTable = new Deck();
        public static List<Col> Columns = new List<Col>();
        List<Card> drawnCardsToShow = new List<Card>();

        public static PictureBox cardToMove;
        public static PictureBox targetedCard;

        public Form1()
        {
            InitializeComponent();
        }

        private void imgDeck_Click(object sender, EventArgs e)
        {
            drawnDeck.Cards.Add(deck.drawCard()); // Siirtää kortin pakasta nostetuihin kortteihin

            foreach (PictureBox obj in drawnDeck.Card_objs) // Poistaa aiemmat nostetut kortit
            {
                obj.Dispose();
            }

            drawnCardsToShow.Clear();

            for (int i = 1; i < drawnDeck.Cards.Count+1; i++)
            {
                if (i > 3) break;
                drawnCardsToShow.Add(drawnDeck.Cards[drawnDeck.Cards.Count - i]);
            }

            drawnCardsToShow.Reverse();

            int Y = 126;
            foreach (Card card in drawnCardsToShow)
            {
                drawnDeck.Card_objs.Add(Actions.createCard(this, 20, Y, card)); // Luo max 3 uutta nostettua korttia
                Y += 30;
            }

            if (deck.Cards.Count == 0)
            {
                imgDeck.Hide();
                imgDeck.Enabled = false;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (cardToMove != null) cardToMove.BorderStyle = BorderStyle.None;
            if (targetedCard != null) targetedCard.BorderStyle = BorderStyle.None;
            cardToMove = null;
            targetedCard = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deck.fillDeck();

            for (int i = 160; i <= 760; i += 100) // Luo 7 listaa korttiriveille
            {
                Columns.Add(new Col(i, -10));
            }

            for (int i = 0; i < 7; i++) // Asettaa kortit riveihin
            {
                Actions.layCards(this, i, i + 1);
            }
        }
    }
}
