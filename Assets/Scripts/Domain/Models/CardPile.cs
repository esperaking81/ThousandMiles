using System;
using System.Collections.Generic;
using Data.Cards;

namespace Domain.Models
{
    public enum PileType
    {
        Battle,
        Speed
    }

    public abstract class CardPile
    {
        private readonly List<BaseCard> _cards = new();
        public IReadOnlyList<BaseCard> Cards => _cards;

        public event Action<BaseCard> OnCardAdded;
        public event Action<BaseCard> OnCardRemoved;
        public event Action<List<BaseCard>> OnCardsDiscarded;

        protected void AddCard(BaseCard card)
        {
            _cards.Add(card);
            OnCardAdded?.Invoke(card);
        }

        protected void RemoveCard(BaseCard card)
        {
            _cards.Remove(card);
            OnCardRemoved?.Invoke(card);
        }

        protected void RemoveCards(List<BaseCard> cards)
        {
            foreach (var card in cards) _cards.Remove(card);
            OnCardsDiscarded?.Invoke(cards);
        }
    }

    public enum DistanceValue
    {
        Distance25 = 25,
        Distance75 = 75,
        Distance100 = 100,
        Distance150 = 150,
        Distance200 = 200
    }

    public class DistancePile : CardPile
    {
        public DistancePile(DistanceValue value)
        {
            Value = value;
        }

        public DistanceValue Value { get; private set; }
    }

    public class BattlePile : CardPile
    {
    }

    public enum SafetyPileType
    {
        Regular, // Holds standard safeties
        CoupFourre // Special pile for coup fourré plays
    }

    public class SafetyPile : CardPile
    {
        public SafetyPile(SafetyPileType type)
        {
            Type = type;
        }

        public SafetyPileType Type { get; private set; }
    }

    public class SpeedPile : CardPile
    {
    }

    public class DiscardPile : CardPile
    {
    }
}