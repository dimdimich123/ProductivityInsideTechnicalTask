using System.Collections.Generic;
using GameCore.BuildingResources;

namespace Configs.Buildings.Storages
{
    [System.Serializable]
    public class StorageLevelConfig
    {
        public List<BuildingResource> ResourceCapacity;
        public List<BuildingResource> PriceInResources;
    }
}