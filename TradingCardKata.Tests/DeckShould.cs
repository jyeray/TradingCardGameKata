using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class DeckShould {
        private Deck deck;
        private Random random;

        [SetUp]
        public void SetUp() {
            random = Substitute.For<Random>();
            deck = new Deck(random);
        }

        [Test]
        public void have_20_cards() {
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
            var cardsWithManaCost = deck.Cards.Where(x => x.ManaCost == manaCost);
            cardsWithManaCost.Should().HaveCount(amountOfCards);
        }
        
        [Test]
        public void draw_a_random_card() {
            var cardNumber = 18;
            random.Next().Returns(cardNumber);
            var expectedCard = deck.Cards[cardNumber];

            var card = deck.DrawCard();

            expectedCard.Should().Be(card);
        }
    }

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

        public Card DrawCard() {
            var cardIndex = random.Next();
            return Cards[cardIndex];
        }
    }

    public class Card {
        public int ManaCost { get; }

        public Card(int manaCost) {
            ManaCost = manaCost;
        }
    }
}