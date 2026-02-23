using UnityEngine;

namespace Data.Cards
{
    [CreateAssetMenu(menuName = "1000Miles/Cards/DistanceCard")]
    public class DistanceCard : BaseCard
    {
        public int mileage;
        public override CardCategory Category => CardCategory.Distance;
    }
}