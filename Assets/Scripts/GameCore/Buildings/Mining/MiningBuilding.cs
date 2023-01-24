using Configs.Buildings.Minings;
using System;
using UniRx;

namespace GameCore.Buildings.Minings
{
    public class MiningBuilding : Building, IMining
    {
        protected MiningBuildingLevel _currentLevelConfig;
        
        public event Action OnBuilt;
        public event Action<float> OnSecondHasPassed;
        public event Action OnMiningEnd;

        private float _elapsedTime;
        private float _elapsedTimeInPercentage;

        public void Init(float buildDuration, MiningBuildingLevel config)
        {
            Init(buildDuration);
            _currentLevelConfig = config;
        }

        public override void EndBuild()
        {
            base.EndBuild();
            OnBuilt?.Invoke();
            StartMining();
        }

        private void StartMining()
        {
            _elapsedTime = 0;

            IDisposable timer = Observable.Timer(TimeSpan.FromSeconds(1))
            .Repeat()
            .Subscribe(_ =>
            {
                _elapsedTime += 1;
                _elapsedTimeInPercentage = _elapsedTime / _currentLevelConfig.MiningDuration;
                OnSecondHasPassed?.Invoke(_elapsedTimeInPercentage);
            });
            timer.AddTo(this);

            Observable.Timer(TimeSpan.FromSeconds(_currentLevelConfig.MiningDuration))
            .Subscribe(_ =>
            {
                timer.Dispose();
                OnSecondHasPassed?.Invoke(1);
                OnMiningEnd?.Invoke();
            })
            .AddTo(this);
        }

        public void GetResources()
        {
            IMining.OnGetResourcesInvoke(_currentLevelConfig.MiningResources);
            StartMining();
        }
    }
}