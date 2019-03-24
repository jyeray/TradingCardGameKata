using FluentAssertions;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class CardGameShould {
        private const int InitialManaSlots = 0;
        private const int InitialPlayerHealth = 30;

        [Test]
        public void start_with_two_players_with_30_of_health() {
            var cardGame = new CardGame();
            cardGame.PlayerOne.Health.Should().Be(InitialPlayerHealth);
            cardGame.PlayerTwo.Health.Should().Be(InitialPlayerHealth);
        }

        [Test]
        public void start_with_players_with_0_mana_slots() {
            var cardGame = new CardGame();
            cardGame.PlayerOne.ManaSlots.Should().Be(InitialManaSlots);
            cardGame.PlayerTwo.ManaSlots.Should().Be(InitialManaSlots);
        }
    }

    public class CardGame {
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public CardGame() {
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }
    }

    public class Player {
        public int Health { get; }
        public int ManaSlots { get; }

        public Player() {
            Health = 30;
            ManaSlots = 0;
        }
    }
}