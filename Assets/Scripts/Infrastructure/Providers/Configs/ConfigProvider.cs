using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameCore.Buildings;
using Configs;
using Configs.Buildings;
using Configs.Buildings.Acceleratings;
using Configs.Buildings.Minings;
using Configs.Buildings.Storages;

namespace Infrastructure.Providers.Configs
{

    public class ConfigProvider
    {
        private BuildingShopConfig[] _shopConfigs;
        private Dictionary<BuildingType, BuildingConfig> _baseBuildingConfigs;
        private Dictionary<BuildingType, MiningBuildingConfig> _miningBuildingConfigs;
        private Dictionary<BuildingType, MiningBuildingLevelsConfig> _upgradableMiningBuildingConfigs;
        private Dictionary<BuildingType, StorageConfig> _storageBuildingConfigs;
        private Dictionary<BuildingType, StorageBuildingLevelsConfig> _upgradableStorageBuildingConfigs;
        private Dictionary<BuildingType, AcceleratingsConfig> _acceleratingBuildingConfigs;

        public ConfigProvider()
        {
            _shopConfigs = Resources.LoadAll<BuildingShopConfig>("Configs/Shop");
            _baseBuildingConfigs = Resources.LoadAll<BuildingConfig>("Configs/Buildings").ToDictionary(x => x.BuildingType, y => y);
            _miningBuildingConfigs = Resources.LoadAll<MiningBuildingConfig>("Configs/Buildings/Minings").ToDictionary(x => x.BuildingType, y => y);
            _upgradableMiningBuildingConfigs = Resources.LoadAll<MiningBuildingLevelsConfig>("Configs/Buildings/Minings").ToDictionary(x => x.BuildingType, y => y);
            _storageBuildingConfigs = Resources.LoadAll<StorageConfig>("Configs/Buildings/Storages").ToDictionary(x => x.BuildingType, y => y);
            _upgradableStorageBuildingConfigs = Resources.LoadAll<StorageBuildingLevelsConfig>("Configs/Buildings/Storages").ToDictionary(x => x.BuildingType, y => y);
            _acceleratingBuildingConfigs = Resources.LoadAll<AcceleratingsConfig>("Configs/Buildings/Acceleratings").ToDictionary(x => x.BuildingType, y => y);
        }

        public BuildingShopConfig[] GetShopConfigs() => _shopConfigs;

        public BuildingConfig GetBaseBuildingConfig(BuildingType buildingType) 
            => _baseBuildingConfigs.TryGetValue(buildingType, out BuildingConfig config) ? config : null;

        public MiningBuildingConfig GetMiningBuildingConfig(BuildingType buildingType)
            => _miningBuildingConfigs.TryGetValue(buildingType, out MiningBuildingConfig config) ? config : null;

        public MiningBuildingLevelsConfig GetMiningUpgradableBuildingConfig(BuildingType buildingType)
           => _upgradableMiningBuildingConfigs.TryGetValue(buildingType, out MiningBuildingLevelsConfig config) ? config : null;

        public StorageConfig GetStorageBuildingConfig(BuildingType buildingType)
            => _storageBuildingConfigs.TryGetValue(buildingType, out StorageConfig config) ? config : null;

        public StorageBuildingLevelsConfig GetStorageUpgradableBuildingConfig(BuildingType buildingType)
            => _upgradableStorageBuildingConfigs.TryGetValue(buildingType, out StorageBuildingLevelsConfig config) ? config : null;

        public AcceleratingsConfig GetAcceleratingsBuildingConfig(BuildingType buildingType)
            => _acceleratingBuildingConfigs.TryGetValue(buildingType, out AcceleratingsConfig config) ? config : null;
        
    }
}