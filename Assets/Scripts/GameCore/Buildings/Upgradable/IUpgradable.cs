using GameCore.BuildingResources;
using System.Collections.Generic;
using System;

namespace GameCore.Buildings.Upgradable
{
    public interface IUpgradable
    {
        public static event Func<List<BuildingResource>, bool> TryGetResources;
        public static bool GetResources(List<BuildingResource> priceInResources)
        {
            if(TryGetResources?.Invoke(priceInResources) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Upgrade();
    }
}