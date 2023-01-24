using Configs.Buildings.Acceleratings;
using GameCore.CommonLogic;

namespace GameCore.Buildings.Acceleratings
{
    public class AcceleratingBuilding : Building, IAccelerating
    {
        protected AcceleratingsConfig _currentConfig;

        public void Init(float buildDuration, AcceleratingsConfig config)
        {
            Init(buildDuration);
            _currentConfig = config;
        }

        public override void EndBuild()
        {
            base.EndBuild();
            SpeedUp();
        }

        public void SpeedUp()
        {
            BuildingTimer.TimeScale += _currentConfig.IncreaseSpeedInPercentage;
        }

        private void OnDestroy()
        {
            BuildingTimer.TimeScale -= _currentConfig.IncreaseSpeedInPercentage;
        }
    }
}