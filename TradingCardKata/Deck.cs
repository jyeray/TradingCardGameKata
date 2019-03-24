using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardKata {
    public class Deck {
        private readonly Random random;
        public List<Card> Cards { get; }

        public Deck(Random random) {
            this.random = random;
            Cards = new List<Card>(Enumerable.Repeat(new Card(0), 2))
                .Concat(Enumerable.Repeat(new Card(1), 2))
                .Concat(Enumerable.Repeat(new Card(2), 3))
                .Concat(Enumerable.Repeat(new Card(3), 4))
                .Concat(Enumerable.Repeat(new Card(4), 3))
                .Concat(Enumerable.Repeat(new Card(5), 2))
                .Concat(Enumerable.Repeat(new Card(6), 2))
                .Concat(Enumerable.Repeat(new Card(7), 1))
                .Concat(Enumerable.Repeat(new Card(8), 1))
                .ToList();
        }

        public virtual Card DrawCard() {
            var cardIndex = random.Next(Cards.Count);
            var drewCard = Cards[cardIndex];
            Cards.RemoveAt(cardIndex);
            return drewCard;
        }
    }
}