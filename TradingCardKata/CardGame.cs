namespace TradingCardKata {
    public class CardGame {
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public CardGame() {
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }
    }
}