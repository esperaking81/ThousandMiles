using System.Collections.Generic;
using Data.Cards;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "1000Miles/Data/DeckData")]
    public class DeckData : ScriptableObject
    {
        public List<BaseCard> cards;
    }
}