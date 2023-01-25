using UnityEngine;
using UI.Shop;

namespace Infrastructure.Providers.Prefabs
{
    public sealed class UIPrefabProvider
    {
        private ShopButton _shopButton;

        public UIPrefabProvider()
        {
            _shopButton = Resources.Load<ShopButton>("Prefabs/UI/BuildingButton");
        }

        public ShopButton ShopButton => _shopButton;
    }
}