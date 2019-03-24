using FluentAssertions;
using NUnit.Framework;

namespace TradingCardKata.Tests {
    public class CardGameShould {
        private const int InitialPlayerHealth = 30;

        [Test]
        public void start_with_two_players_with_30_of_health() {
            var cardGame = new CardGame();
            cardGame.PlayerOne.Health.Should().Be(InitialPlayerHealth);
            cardGame.PlayerTwo.Health.Should().Be(InitialPlayerHealth);
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

        public Player() {
            Health = 30;
        }
    }
}