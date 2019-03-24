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
            GiveInitialHandTo(PlayerOne, playerOneDeck);
            GiveInitialHandTo(PlayerTwo, playerTwoDeck);
            PlayerOne.ManaSlots++;
        }

        private static void GiveInitialHandTo(Player playerOne, Deck oneDeck) {
            playerOne.Hand.Add(oneDeck.DrawCard());
            playerOne.Hand.Add(oneDeck.DrawCard());
            playerOne.Hand.Add(oneDeck.DrawCard());
        }
    }
}