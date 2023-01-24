using System.Collections.Generic;
using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Minings
{
    [CreateAssetMenu(fileName = "MiningBuildingLevelsConfig", menuName = "Configs/MiningBuildingLevelsConfig", order = 2)]
    public sealed class MiningBuildingLevelsConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private List<MiningBuildingLevel> _levels;

        public BuildingType BuildingType => _buildingType;
        public List<MiningBuildingLevel> Levels => _levels;
    }
}