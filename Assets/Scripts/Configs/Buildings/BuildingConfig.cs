using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings
{
    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "Configs/BuildingConfig", order = 7)]
    public class BuildingConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;

        [SerializeField] private float _buildDurationInSeconds;
        [SerializeField] private float _buildDurationInMinutes;
        [SerializeField] private float _buildDurationInHours;

        public BuildingType BuildingType => _buildingType;

        public float BuildDurationInSeconds 
            => _buildDurationInHours * 60 + _buildDurationInMinutes * 60 + _buildDurationInSeconds;
    }
}