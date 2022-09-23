﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace korttipeli
{
    public class Card
    {
        public static string[] suites = { "Hearts", "Spades", "Clubs", "Diamonds" };

        public int Value;

        public string Suite;

        public Image Image;

        public string Name;

        public Card(int value, string suite)
        {
            Value = value;
            Suite = suite;
            Name = Suite[0] + Value.ToString();
        }
    }
}
