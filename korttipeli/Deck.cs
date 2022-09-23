﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace korttipeli
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();
        public List<PictureBox> Card_objs = new List<PictureBox>();

        public void fillDeck()
        {
            for (int i = 1; i < 14; i++)
            {
                foreach (string suite in Card.suites)
                {
                    Card card = new Card(i, suite);
                    card.Name = card.Suite[0].ToString() + card.Value;
                    card.CardPicture = Actions.GetImage(card.Name);
                    Cards.Add(card);
                }
            }

            shuffleDeck();
            shuffleDeck();
        }

        public void shuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int val = rand.Next(0, Cards.Count);

                Card temp = Cards[val];
                Cards[val] = Cards[0];
                Cards[0] = temp;
            }
        }

        public Card drawCard()
        {
            Card temp = Cards[0];

            Cards.RemoveAt(0);

            return temp;
        }
    }
}
