using UnityEngine;
using GameCore.Buildings;
using Infrastructure.Providers.Configs;
using Infrastructure.CommonLogic;
using GameCore.Buildings.Minings;
using GameCore.Buildings.Upgradable;
using GameCore.Buildings.Storages;
using GameCore.Buildings.Acceleratings;
using Configs.Buildings;
using Configs.Buildings.Minings;
using Configs.Buildings.Storages;
using Configs.Buildings.Acceleratings;

namespace Infrastructure.Factories
{
    public sealed class BuildingFactory : IVisitor
    {
        private ConfigProvider _configProvider;

        public BuildingFactory(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public Building Visit(Building building)
        {
            Building newBuilding = Object.Instantiate(building);
            BuildingConfig config = _configProvider.GetBaseBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds);
            return newBuilding;
        }

        public Building Visit(MiningBuilding building)
        {
            MiningBuilding newBuilding = Object.Instantiate(building);
            MiningBuildingConfig config = _configProvider.GetMiningBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds, config.Config);
            return newBuilding;
        }

        public Building Visit(UpgradableMiningBuilding building)
        {
            UpgradableMiningBuilding newBuilding = Object.Instantiate(building);
            MiningBuildingLevelsConfig config = _configProvider.GetMiningUpgradableBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds, config);
            return newBuilding;
        }

        public Building Visit(StorageBuilding building)
        {
            StorageBuilding newBuilding = Object.Instantiate(building);
            StorageConfig config = _configProvider.GetStorageBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds, config.Config);
            return newBuilding;
        }

        public Building Visit(UpgradableStorageBuilding building)
        {
            UpgradableStorageBuilding newBuilding = Object.Instantiate(building);
            StorageBuildingLevelsConfig config = _configProvider.GetStorageUpgradableBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds, config);
            return newBuilding;
        }

        public Building Visit(AcceleratingBuilding building)
        {
            AcceleratingBuilding newBuilding = Object.Instantiate(building);
            AcceleratingsConfig config = _configProvider.GetAcceleratingsBuildingConfig(newBuilding.BuildingType);
            newBuilding.Init(config.BuildDurationInSeconds, config);
            return newBuilding;
        }
    }
}