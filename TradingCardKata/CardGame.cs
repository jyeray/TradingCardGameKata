namespace TradingCardKata {
    public class CardGame {
        private readonly Deck playerOneDeck;
        private readonly Deck playerTwoDeck;
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public CardGame(Deck playerOneDeck, Deck playerTwoDeck) {
            PlayerOne = new Player();
            PlayerTwo = new Player();
            this.playerOneDeck = playerOneDeck;
            this.playerTwoDeck = playerTwoDeck;
        }

        public void Start() {
            PlayerOne.Hand.Add(playerOneDeck.DrawCard());
            PlayerOne.Hand.Add(playerOneDeck.DrawCard());
            PlayerOne.Hand.Add(playerOneDeck.DrawCard());
            PlayerTwo.Hand.Add(playerTwoDeck.DrawCard());
            PlayerTwo.Hand.Add(playerTwoDeck.DrawCard());
            PlayerTwo.Hand.Add(playerTwoDeck.DrawCard());
        }
    }
}