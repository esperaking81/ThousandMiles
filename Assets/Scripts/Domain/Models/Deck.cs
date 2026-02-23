using System.Collections.Generic;
using Data.Cards;

namespace Domain.Models
{
    public class Deck
    {
        public Deck(List<BaseCard> cards)
        {
            Cards = cards;
        }

        public List<BaseCard> Cards { get; }


        public BaseCard DrawCard()
        {
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}