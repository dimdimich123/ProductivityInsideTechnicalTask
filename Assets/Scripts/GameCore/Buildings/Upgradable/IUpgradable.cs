using GameCore.BuildingResources;
using System.Collections.Generic;
using System;

namespace GameCore.Buildings.Upgradable
{
    public interface IUpgradable
    {
        public static event Func<List<BuildingResource>, bool> TryUgradeBuilding;
        public static bool TryUpgrade(List<BuildingResource> priceInResources)
        {
            if(TryUgradeBuilding?.Invoke(priceInResources) == true)
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