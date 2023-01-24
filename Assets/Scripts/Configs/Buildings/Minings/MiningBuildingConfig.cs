using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Minings {
    [CreateAssetMenu(fileName = "MiningBuildingConfig", menuName = "Configs/MiningBuildingConfig", order = 1)]
    public sealed class MiningBuildingConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private MiningBuildingLevel _config;

        public BuildingType BuildingType => _buildingType;
        public MiningBuildingLevel Config => _config;
    }
}