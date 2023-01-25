using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Acceleratings {
    [CreateAssetMenu(fileName = "AcceleratingsConfig", menuName = "Configs/AcceleratingsConfig", order = 5)]
    public class AcceleratingsConfig : BuildingConfig
    {
        [Range(0, 1)]
        [SerializeField] private float _increaseSpeedInPercentage;

        public float IncreaseSpeedInPercentage => _increaseSpeedInPercentage;
    }
}