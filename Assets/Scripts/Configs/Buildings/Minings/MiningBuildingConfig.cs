using UnityEngine;

namespace Configs.Buildings.Minings {
    [CreateAssetMenu(fileName = "MiningBuildingConfig", menuName = "Configs/MiningBuildingConfig", order = 1)]
    public sealed class MiningBuildingConfig : BuildingConfig
    {
        [SerializeField] private MiningBuildingLevel _config;

        public MiningBuildingLevel Config => _config;
    }
}