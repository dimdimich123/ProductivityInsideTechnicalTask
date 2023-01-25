using System.Collections.Generic;
using UnityEngine;
using GameCore.Buildings;

namespace Infrastructure.Providers.Prefabs
{
    public sealed class PrefabProvider
    {
        private Dictionary<BuildingType, Building> _buildings = new Dictionary<BuildingType, Building>();

        public PrefabProvider()
        {
            AddRange(Resources.LoadAll<Building>("Prefabs/Buildings/AcceleratingBuildings"));
            AddRange(Resources.LoadAll<Building>("Prefabs/Buildings/Decorative"));
            AddRange(Resources.LoadAll<Building>("Prefabs/Buildings/Mining"));
            AddRange(Resources.LoadAll<Building>("Prefabs/Buildings/Storages"));
        }

        private void AddRange(Building[] buildings)
        {
            foreach (Building building in buildings)
            {
                _buildings.TryAdd(building.BuildingType, building);
            }
        }

        public Building GetBuilding(BuildingType buildingType) 
            => _buildings.TryGetValue(buildingType, out Building building) ? building : null;
    }
}