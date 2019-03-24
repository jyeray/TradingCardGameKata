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
    }

    public class Deck {
        public List<Card> Cards { get;  }

        public Deck() {
            Cards = new List<Card>(Enumerable.Repeat(new Card(), 20));
        }
    }

    public class Card { }
}