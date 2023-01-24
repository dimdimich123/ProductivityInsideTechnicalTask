using GameCore.Buildings.Minings;
using Configs.Buildings.Minings;

namespace GameCore.Buildings.Upgradable
{
    public class UpgradableMiningBuilding : MiningBuilding, IUpgradable
    {
        private int _currentLevel = 0;
        private MiningBuildingLevelsConfig _levelsConfig;

        public void Init(float buildDuration, MiningBuildingLevelsConfig levelsConfig)
        {
            Init(buildDuration, levelsConfig.Levels[_currentLevel]);
            _levelsConfig = levelsConfig;
            _currentLevel++;
        }

        public void Upgrade()
        {
            if(IUpgradable.TryUpgrade(_levelsConfig.Levels[_currentLevel].PriceInResources))
            {
                _currentLevel++;
                _currentLevelConfig = _levelsConfig.Levels[_currentLevel];
            }
        }
    }
}