using UnityEngine;

namespace Data.Cards
{
    public enum RemedyType
    {
        Gasoline,
        SpareTire,
        Repairs,
        EndOfLimit,
        Roll
    }

    [CreateAssetMenu(menuName = "1000Miles/Cards/RemedyCard")]
    public class RemedyCard : BaseCard
    {
        public HazardType fixesHazard;
        public RemedyType remedyType;
        public override CardCategory Category => CardCategory.Remedy;
    }
}