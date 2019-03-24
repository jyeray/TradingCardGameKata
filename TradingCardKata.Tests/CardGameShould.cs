using System;
using System.Collections.Generic;
using System.Linq;
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
            playerOneDeck = Substitute.For<Deck>();
            playerTwoDeck = Substitute.For<Deck>();
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
        public void player_two_receive_his_initial_hand_when_game_starts() {
            var expectedPlayerTwoInitialHand = GivenNextCardsFor(playerTwoDeck, 
                new Card(2),
                new Card(2),
                new Card(5));

            cardGame.Start();

            cardGame.PlayerTwo.Hand.Should().BeEquivalentTo(expectedPlayerTwoInitialHand);
        }

        [Test]
        public void player_one_receive_his_initial_hand_plus_other_card_when_game_starts() {
            var expectedHand = GivenNextCardsFor(playerOneDeck,
                new Card(4),
                new Card(8),
                new Card(3),
                new Card(7));

            cardGame.Start();

            cardGame.PlayerOne.Hand.Should().BeEquivalentTo(expectedHand);
        }

        [Test]
        public void active_player_receive_one_mana_slot() {
            const int manaSlots = InitialManaSlots + 1;
            cardGame.Start();
            cardGame.PlayerOne.ManaSlots.Should().Be(manaSlots);
        }

        private static List<Card> GivenNextCardsFor(Deck deck, Card firstCard, params Card[] followingCards) {
            deck.DrawCard().Returns(firstCard, followingCards);
            return new List<Card> { firstCard }.Concat(followingCards).ToList();
        }
    }
}