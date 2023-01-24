using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Acceleratings {
    [CreateAssetMenu(fileName = "AcceleratingsConfig", menuName = "Configs/AcceleratingsConfig", order = 5)]
    public class AcceleratingsConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;

        [Range(0, 1)]
        [SerializeField] private float _increaseSpeedInPercentage;

        public BuildingType BuildingType => _buildingType;
        public float IncreaseSpeedInPercentage => _increaseSpeedInPercentage;
    }
}