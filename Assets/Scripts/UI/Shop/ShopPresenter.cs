using System;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Grid;
using GameCore.BuildingResources;
using GameCore.Buildings;

namespace UI.Shop
{
    [RequireComponent(typeof(ShopView))]
    public sealed class ShopPresenter : MonoBehaviour
    {
        [SerializeField] private BuildingsGrid _grid;

        private ShopView _view;
        private ShopModel _model;

        public static event Func<List<BuildingResource>, bool> OnTryBuyBuilding;

        private void Awake()
        {
            _view = GetComponent<ShopView>();
            _model = new ShopModel(_grid);
        }

        private void OnEnable()
        {
            _view.OnShopButton += BuyBuilding;
        }

        private bool BuyBuilding(BuildingType building, List<BuildingResource> priceInResources)
        {
            if(OnTryBuyBuilding?.Invoke(priceInResources) == true)
            {
                return _model.BuyBuilding(building);
            }
            return false;
        }

        private void OnDisable()
        {
            _view.OnShopButton -= BuyBuilding;
        }
    }
}