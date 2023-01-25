using GameCore.Buildings;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Buildings.Storages
{
    [CreateAssetMenu(fileName = "StorageBuildingLevelsConfig", menuName = "Configs/StorageBuildingLevelsConfig", order = 4)]
    public class StorageBuildingLevelsConfig : BuildingConfig
    {
        [SerializeField] private List<StorageLevelConfig> _levels;

        public List<StorageLevelConfig> Levels => _levels;
    }
}