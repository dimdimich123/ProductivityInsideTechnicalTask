using GameCore.BuildingResources;
using System.Collections.Generic;
using System;

namespace GameCore.Buildings.Storages
{
    public interface IStorage
    {
        public static event Action<List<BuildingResource>> OnStorageBuilt;
        public static event Action<List<BuildingResource>> OnStorageBreake;

        public static void OnStorageBuiltInvoke(List<BuildingResource> resourceCapacity) 
            => OnStorageBuilt?.Invoke(resourceCapacity);

        public static void OnStorageBreakeInvoke(List<BuildingResource> resourceCapacity)
           => OnStorageBreake?.Invoke(resourceCapacity);

        public void Store();
    }
}