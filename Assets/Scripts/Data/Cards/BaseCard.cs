using UnityEngine;

namespace Data.Cards
{
    public enum CardCategory
    {
        Hazard,
        Safety,
        Remedy,
        Distance
    }

    public abstract class BaseCard : ScriptableObject
    {
        public Sprite faceSprite;
        public string label;
        [TextArea] public string description;
        public int totalInstanceCount;
        public abstract CardCategory Category { get; }
    }
}