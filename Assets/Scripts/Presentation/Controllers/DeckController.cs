using System.Collections.Generic;
using Data;
using Data.Cards;
using UnityEngine;

namespace Presentation.Controllers
{
    public class DeckController
    {
        public static List<BaseCard> InitializeDeck(DeckData deckData)
        {
            var deck = new List<BaseCard>();

            foreach (var card in deckData.cards)
                for (var i = 0; i < card.totalInstanceCount; i++)
                    deck.Add(card);

            return Shuffle(deck);
        }

        private static List<BaseCard> Shuffle(List<BaseCard> deck)
        {
            for (var i = 0; i < deck.Count; i++)
            {
                var temp = deck[i];
                var randomIndex = Random.Range(i, deck.Count);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }

            return deck;
        }
    }
}