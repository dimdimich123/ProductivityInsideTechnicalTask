using GameCore.Buildings.Storages;
using Configs.Buildings.Storages;
using Infrastructure.CommonLogic;

namespace GameCore.Buildings.Upgradable
{
    public class UpgradableStorageBuilding : StorageBuilding, IUpgradable
    {
        private int _currentLevel = 0;
        private StorageBuildingLevelsConfig _levelsConfig;

        public void Init(float buildDuration, StorageBuildingLevelsConfig levelsConfig)
        {
            Init(buildDuration, levelsConfig.Levels[_currentLevel]);
            _levelsConfig = levelsConfig;
            _currentLevel++;
        }

        public void Upgrade()
        {
            if (_currentLevel < _levelsConfig.Levels.Count)
            {
                if (IUpgradable.TryUpgrade(_levelsConfig.Levels[_currentLevel].PriceInResources))
                {
                    OnDestroy();
                    _currentLevelConfig = _levelsConfig.Levels[_currentLevel];
                    _currentLevel++;
                    Store();
                }
            }
        }

        public override Building AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}