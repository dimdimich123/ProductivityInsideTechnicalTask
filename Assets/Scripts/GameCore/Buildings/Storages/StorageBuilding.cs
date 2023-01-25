using Configs.Buildings.Storages;
using Infrastructure.CommonLogic;

namespace GameCore.Buildings.Storages
{
    public class StorageBuilding : Building, IStorage
    {
        protected StorageLevelConfig _currentLevelConfig;

        public void Init(float buildDuration, StorageLevelConfig config)
        {
            Init(buildDuration);
            _currentLevelConfig = config;
        }

        public override void EndBuild()
        {
            base.EndBuild();
            Store();
        }

        public void Store()
        {
            IStorage.OnStorageBuiltInvoke(_currentLevelConfig.ResourceCapacity);
        }

        protected virtual void OnDestroy()
        {
            IStorage.OnStorageBreakeInvoke(_currentLevelConfig.ResourceCapacity);
        }

        public override Building AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}