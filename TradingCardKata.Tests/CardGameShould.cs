using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class CardGameShould {
        private CardGame cardGame;
        private Deck playerOneDeck;
        private Deck playerTwoDeck;
        private const int InitialManaSlots = 0;
        private const int InitialPlayerHealth = 30;

        [SetUp]
        public void SetUp() {
            playerOneDeck = Substitute.For<Deck>(new object[] {null} );
            playerTwoDeck = Substitute.For<Deck>(new object[] {null} );
            cardGame = new CardGame(playerOneDeck, playerTwoDeck);
        }

        [Test]
        public void start_with_two_players_with_30_of_health() {
            cardGame.PlayerOne.Health.Should().Be(InitialPlayerHealth);
            cardGame.PlayerTwo.Health.Should().Be(InitialPlayerHealth);
        }

        [Test]
        public void start_with_players_with_0_mana_slots() {
            cardGame.PlayerOne.ManaSlots.Should().Be(InitialManaSlots);
            cardGame.PlayerTwo.ManaSlots.Should().Be(InitialManaSlots);
        }

        [Test]
        public void each_player_receive_his_initial_hand() {
            var expectedPlayerOneInitialHand = GivenInitialHandFor(playerOneDeck, 
                new Card(4),
                new Card(8),
                new Card(3));
            var expectedPlayerTwoInitialHand = GivenInitialHandFor(playerTwoDeck, 
                new Card(2),
                new Card(2),
                new Card(5));

            cardGame.Start();

            cardGame.PlayerOne.Hand.Should().BeEquivalentTo(expectedPlayerOneInitialHand);
            cardGame.PlayerTwo.Hand.Should().BeEquivalentTo(expectedPlayerTwoInitialHand);
        }

        private List<Card> GivenInitialHandFor(Deck deck, Card firstCard, Card secondCard, Card thirdCard) {
            deck.DrawCard().Returns(firstCard, secondCard, thirdCard);
            return new List<Card> {
                firstCard,
                secondCard,
                thirdCard
            };
        }
    }
}