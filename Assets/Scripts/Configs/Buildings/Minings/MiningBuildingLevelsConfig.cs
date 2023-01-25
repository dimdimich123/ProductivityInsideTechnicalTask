using System.Collections.Generic;
using UnityEngine;

namespace Configs.Buildings.Minings
{
    [CreateAssetMenu(fileName = "MiningBuildingLevelsConfig", menuName = "Configs/MiningBuildingLevelsConfig", order = 2)]
    public sealed class MiningBuildingLevelsConfig : BuildingConfig
    {
        [SerializeField] private List<MiningBuildingLevel> _levels;

        public List<MiningBuildingLevel> Levels => _levels;
    }
}