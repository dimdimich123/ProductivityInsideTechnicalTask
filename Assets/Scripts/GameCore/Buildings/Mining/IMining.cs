using GameCore.BuildingResources;
using System.Collections.Generic;
using System;

namespace GameCore.Buildings.Minings
{
    public interface IMining
    {
        public static event Action<List<BuildingResource>> OnGetResources;

        public static void OnGetResourcesInvoke(List<BuildingResource> miningResources)
            => OnGetResources?.Invoke(miningResources);

        public void GetResources();
    }
}