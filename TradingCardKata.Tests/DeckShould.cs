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

        [Test]
        public void have_2_card_with_0_mana_cost() {
            var deck = new Deck();
            var cardsWithManaCost = deck.Cards.Where(x => x.ManaCost == 0);
            cardsWithManaCost.Should().HaveCount(2);
        }
    }

    public class Deck {
        public List<Card> Cards { get; }

        public Deck() {
            Cards = new List<Card>(Enumerable.Repeat(new Card(0), 2))
                .Concat(Enumerable.Repeat(new Card(11), 18))
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