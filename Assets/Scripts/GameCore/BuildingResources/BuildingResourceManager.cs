using System;
using System.Collections.Generic;
using UnityEngine;
using GameCore.CommonLogic;
using GameCore.Buildings.Minings;
using GameCore.Buildings.Storages;
using GameCore.Buildings.Upgradable;
using UI.Shop;

namespace GameCore.BuildingResources
{
    public sealed class BuildingResourceManager : MonoBehaviour
    {
        public static event Action<ResourceType, float, float> OnResourceChange;

        private const float _defaultCurrenResources = 70;
        private const float _defaultMaxResources = 100;

        private Dictionary<ResourceType, CurrentAndMaxValue> _currentResources = new Dictionary<ResourceType, CurrentAndMaxValue>();

        private void Awake()
        {
            int resourceTypesCount = Enum.GetNames(typeof(ResourceType)).Length;
            for(int i = 0; i < resourceTypesCount; ++i)
            {
                _currentResources.Add((ResourceType)i, new CurrentAndMaxValue(_defaultCurrenResources, _defaultMaxResources));
            }
        }

        private void Start()
        {
            int resourceTypesCount = Enum.GetNames(typeof(ResourceType)).Length;
            for (int i = 0; i < resourceTypesCount; ++i)
            {
                OnResourceChange?.Invoke((ResourceType)i, _defaultCurrenResources, _defaultMaxResources);
            }
        }

        private void GetResources(List<BuildingResource> resources)
        {
            foreach(BuildingResource resource in resources)
            {
                _currentResources[resource.Resource].Current += resource.Value;
                if(_currentResources[resource.Resource].Current > _currentResources[resource.Resource].Max)
                {
                    _currentResources[resource.Resource].Current = _currentResources[resource.Resource].Max;
                }
                OnResourceChange?.Invoke(resource.Resource, _currentResources[resource.Resource].Current, _currentResources[resource.Resource].Max);
            }
        }

        private void IncreaseStorage(List<BuildingResource> resources)
        {
            foreach (BuildingResource resource in resources)
            {
                _currentResources[resource.Resource].Max += resource.Value;
                OnResourceChange?.Invoke(resource.Resource, _currentResources[resource.Resource].Current, _currentResources[resource.Resource].Max);
            }
        }
        
        private void DecreaseStorage(List<BuildingResource> resources)
        {
            foreach (BuildingResource resource in resources)
            {
                _currentResources[resource.Resource].Max -= resource.Value;
                OnResourceChange?.Invoke(resource.Resource, _currentResources[resource.Resource].Current, _currentResources[resource.Resource].Max);
            }
        }

        private bool TryBuyBuilding(List<BuildingResource> priceInResources)
        {
            foreach (BuildingResource resource in priceInResources)
            {
                if(resource.Value > _currentResources[resource.Resource].Current)
                {
                    return false;
                }
            }

            foreach (BuildingResource resource in priceInResources)
            {
                _currentResources[resource.Resource].Current -= resource.Value;
                OnResourceChange?.Invoke(resource.Resource, _currentResources[resource.Resource].Current, _currentResources[resource.Resource].Max);
            }

            return true;
        }

        private void OnEnable()
        {
            IMining.OnGetResources += GetResources;
            IStorage.OnStorageBuilt += IncreaseStorage;
            IStorage.OnStorageBreake += DecreaseStorage;
            IUpgradable.TryUgradeBuilding += TryBuyBuilding;
            ShopPresenter.OnTryBuyBuilding += TryBuyBuilding;
        }

        private void OnDisable()
        {
            IMining.OnGetResources -= GetResources;
            IStorage.OnStorageBuilt -= IncreaseStorage;
            IStorage.OnStorageBreake -= DecreaseStorage;
            IUpgradable.TryUgradeBuilding -= TryBuyBuilding;
            ShopPresenter.OnTryBuyBuilding -= TryBuyBuilding;
        }
    }
}