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
        Deck drawnDeck = new Deck();
        public static Deck cardsOnTable = new Deck();
        public static List<Col> Columns = new List<Col>();

        public static PictureBox cardToMove;
        public static PictureBox targetedCard;

        public Form1()
        {
            InitializeComponent();

            deck.fillDeck();

            for (int i = 160; i <= 760; i+=100) // Luo 7 listaa korttiriveille
            {
                Columns.Add(new Col(i, -10));
            }

            for (int i = 0; i < 7; i++) // Asettaa kortit riveihin
            {
                Actions.layCards(this, i, i+1);
            }
        }

        private void imgDeck_Click(object sender, EventArgs e)
        {
            drawnDeck.Cards.Add(deck.drawCard()); // Siirtää kortin pakasta nostetuihin kortteihin

            foreach (PictureBox obj in drawnDeck.Card_objs) // Poistaa aiemmat nostetut kortit
            {
                obj.Dispose();
            }

            int Y = 126;
            for (int i = 1; i < drawnDeck.Cards.Count+1; i++)
            {
                if (i > 3) break;
                drawnDeck.Card_objs.Add(Actions.createCard(this, 12, Y, drawnDeck.Cards[drawnDeck.Cards.Count - i])); // Luo max 3 uutta nostettua korttia
                Y += 30;
            }

            if (deck.Cards.Count == 0)
            {
                imgDeck.Hide();
                imgDeck.Enabled = false;
            }
        }
    }
}
