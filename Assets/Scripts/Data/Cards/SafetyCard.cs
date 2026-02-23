using System.Collections.Generic;
using UnityEngine;

namespace Data.Cards
{
    [CreateAssetMenu(menuName = "1000Miles/Cards/SafetyCard")]
    public class SafetyCard : BaseCard
    {
        public enum SafetyType
        {
            ExtraTank,
            RightOfWay,
            PunctureProof,
            DrivingAce
        }

        public SafetyType safetyType;
        public List<HazardType> immuneTo;
        public override CardCategory Category => CardCategory.Safety;
    }
}