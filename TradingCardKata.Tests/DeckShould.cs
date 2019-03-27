using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static System.Linq.Enumerable;

namespace TradingCardKata.Tests {
    public class DeckShould {
        private const int InitialAmountOfCards = 20;
        private DefaultDeck deck;
        private Random random;

        [SetUp]
        public void SetUp() {
            random = Substitute.For<Random>();
            deck = new DefaultDeck(random);
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
            const int aaa = 5;
            GivenNextCard(aaa);

            deck.DrawCard();

            deck.Cards.Should().HaveCount( expected: InitialAmountOfCards - 1);
            deck.Cards.Where(x => x.ManaCost == 2).Should().HaveCount(2);
        }

        [Test]
        public void call_random_with_cards_amount() {
            const int cardNumber = 5;
            GivenNextCard(cardNumber);

            deck.DrawCard();
            deck.DrawCard();

            Received.InOrder(() => {
                random.Next(InitialAmountOfCards);
                random.Next(InitialAmountOfCards - 1);
            });
        }

        [Test]
        public void be_empty_when_draw_all_cards() {
            deck = new DefaultDeck(new Random());

            20.Times(deck.DrawCard);
            
            deck.Cards.Should().HaveCount(0);
        }

        private void GivenNextCard(int cardNumber) {
            random.Next(InitialAmountOfCards).Returns(cardNumber);
        }

    }


    public static class MyClass {
        public static void Times(this int times, Func<object> action) {
            foreach (var i in Range(0, times)) action();
        }
    }
}