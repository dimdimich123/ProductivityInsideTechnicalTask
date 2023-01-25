using System.Collections.Generic;
using GameCore.BuildingResources;

namespace Configs.Buildings.Minings
{
    [System.Serializable]
    public sealed class MiningBuildingLevel
    {
        public List<BuildingResource> MiningResources;
        public float MiningDuration;
        public List<BuildingResource> PriceInResources;
    }
}