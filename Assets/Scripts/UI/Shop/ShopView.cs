using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Configs;
using Infrastructure.Providers.Prefabs;
using Infrastructure.Providers.Configs;
using GameCore.Buildings;
using GameCore.BuildingResources;

namespace UI.Shop
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ShopView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _contentTransform;

        private CanvasGroup _canvasGroup;
        private ConfigProvider _configProvider;
        private UIPrefabProvider _uiPrefabProvider; 

        private List<ShopButton> _shopButtons = new List<ShopButton>();

        public event Func<BuildingType, List<BuildingResource>, bool> OnShopButton;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _configProvider = new ConfigProvider();
            _uiPrefabProvider = new UIPrefabProvider();
            BuildingShopConfig[] configs = _configProvider.GetShopConfigs();

            foreach (BuildingShopConfig config in configs)
            {
                CreateButton(config, _uiPrefabProvider.ShopButton);
            }
        }

        private void CreateButton(BuildingShopConfig config, ShopButton buttonPrefab)
        {
            ShopButton newShopButton = Instantiate(buttonPrefab, _contentTransform);
            newShopButton.Init(config.BuildingSprite, config.Description, config.PriceInResources);
            newShopButton.Button.onClick.AddListener(() => ShopButton(config.Building, config.PriceInResources));
            _shopButtons.Add(newShopButton);
        }

        private void ShopButton(BuildingType building, List<BuildingResource> priceInResources)
        {
            bool? canBuy = OnShopButton?.Invoke(building, priceInResources);
            if(canBuy == true)
            {
                Close();
            }
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        public void Close()
        {
            _canvasGroup.Close();
        }

        public void Open()
        {
            _canvasGroup.Open();
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            foreach(ShopButton button in _shopButtons)
            {
                button.Button.onClick.RemoveAllListeners();
            }
        }
    }
}