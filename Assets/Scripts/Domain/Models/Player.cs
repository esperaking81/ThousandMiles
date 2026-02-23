using System;
using System.Collections.Generic;
using System.Linq;
using Data.Cards;

namespace Domain.Models
{
    public class Player
    {
        public Player(string name, bool isLocalPlayer = false)
        {
            Name = name;
            IsLocalPlayer = isLocalPlayer;
            Hand = new List<BaseCard>();

            // Distance piles: 200, 150, 100, 75, 25 (in play order)
            DistancePiles = new List<DistancePile>
            {
                new(DistanceValue.Distance200),
                new(DistanceValue.Distance150),
                new(DistanceValue.Distance100),
                new(DistanceValue.Distance75),
                new(DistanceValue.Distance25)
            };

            // 2 regular safety piles + 1 for Coup Fourré
            SafetyPiles = new List<SafetyPile>
            {
                new(SafetyPileType.Regular),
                new(SafetyPileType.Regular),
                new(SafetyPileType.CoupFourre)
            };

            BattlePile = new BattlePile();
            SpeedPile = new SpeedPile();
        }

        public string Name { get; }
        public bool IsLocalPlayer { get; private set; }
        public List<BaseCard> Hand { get; }

        public int TotalDistance
        {
            get { return DistancePiles.Where(pile => pile.Cards.Count > 0).Sum(pile => (int)pile.Value); }
        }

        // 5 distance piles (200 → 25)
        public List<DistancePile> DistancePiles { get; }

        // Battle and Speed piles
        public BattlePile BattlePile { get; private set; }
        public SpeedPile SpeedPile { get; private set; }

        // 3 safety piles: 2 regular + 1 Coup Fourré
        public List<SafetyPile> SafetyPiles { get; }

        // Helper to get the coup fourré pile specifically
        public SafetyPile CoupFourrePile => SafetyPiles[^1];

        // Helper for regular safety piles
        public IEnumerable<SafetyPile> RegularSafetyPiles => SafetyPiles.Take(2);

        public event Action<BaseCard> OnCardAdded;
        
        public event Action<BaseCard> OnCardMoved;

        public void PlayCard(BaseCard card)
        {
            
        }

        public void AddCard(BaseCard card)
        {
            Hand.Add(card);
            OnCardAdded?.Invoke(card);
        }
    }
}