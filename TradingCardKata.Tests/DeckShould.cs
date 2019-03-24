using System;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class DeckShould {
        private const int InitialAmountOfCards = 20;
        private Deck deck;
        private Random random;

        [SetUp]
        public void SetUp() {
            random = Substitute.For<Random>();
            deck = new Deck(random);
        }

        [Test]
        public void have_20_cards() {
            deck.Cards.Should().HaveCount(InitialAmountOfCards);
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
            const int cardNumber = 18;
            GivenNextCard(cardNumber);
            var expectedCard = deck.Cards[cardNumber];

            var card = deck.DrawCard();

            expectedCard.Should().Be(card);
        }

        [Test]
        public void remove_the_drew_card_from_deck() {
            const int cardNumber = 5;
            GivenNextCard(cardNumber);

            deck.DrawCard();

            deck.Cards.Should().HaveCount(InitialAmountOfCards - 1);
            deck.Cards.Where(x => x.ManaCost == 2).Should().HaveCount(2);
        }

        private void GivenNextCard(int cardNumber) {
            random.Next(InitialAmountOfCards).Returns(cardNumber);
        }
    }
}