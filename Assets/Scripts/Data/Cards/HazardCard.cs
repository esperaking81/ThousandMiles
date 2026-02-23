using UnityEngine;

namespace Data.Cards
{
    public enum HazardType
    {
        SpeedLimit,
        OutOfGas,
        FlatTire,
        Accident,
        Stop
    }

    [CreateAssetMenu(menuName = "1000Miles/Cards/HazardCard")]
    public class HazardCard : BaseCard
    {
        public HazardType hazardType;
        public override CardCategory Category => CardCategory.Hazard;
    }
}