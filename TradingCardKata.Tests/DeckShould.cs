using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class DeckShould {

        [Test]
        public void have_20_cards() {
            var deck = new Deck();
            deck.Cards.Should().HaveCount(20);
        }

        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 3)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 1)]
        [TestCase(8, 1)]
        public void have_cards_with_mana_cost(int manaCost, int amountOfCards) {
            var deck = new Deck();
            var cardsWithManaCost = deck.Cards.Where(x => x.ManaCost == manaCost);
            cardsWithManaCost.Should().HaveCount(amountOfCards);
        }
    }

    public class Deck {
        public List<Card> Cards { get; }

        public Deck() {
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
    }

    public class Card {
        public int ManaCost { get; }

        public Card(int manaCost) {
            ManaCost = manaCost;
        }
    }
}