using System.Collections.Generic;

namespace TradingCardKata {
    public class Player {
        public int Health { get; }
        public int ManaSlots { get; }
        public List<Card> Hand { get; }

        public Player() {
            Health = 30;
            ManaSlots = 0;
            Hand = new List<Card>();
        }
    }
}