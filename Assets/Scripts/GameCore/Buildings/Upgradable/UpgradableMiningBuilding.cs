using GameCore.Buildings.Minings;
using Configs.Buildings.Minings;
using Infrastructure.CommonLogic;

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
            if(_currentLevel < _levelsConfig.Levels.Count)
            {
                if (IUpgradable.TryUpgrade(_levelsConfig.Levels[_currentLevel].PriceInResources))
                {
                    _currentLevelConfig = _levelsConfig.Levels[_currentLevel];
                    _currentLevel++;
                }
            }
        }

        public override Building AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}