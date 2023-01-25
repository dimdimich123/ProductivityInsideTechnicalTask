using GameCore.Buildings;
using GameCore.Grid;
using Infrastructure.Providers.Prefabs;
using Infrastructure.Providers.Configs;
using Infrastructure.Factories;

namespace UI.Shop
{
    public sealed class ShopModel
    {
        private BuildingFactory _buildingFactory;
        private PrefabProvider _prefabProvider;

        private BuildingsGrid _grid;

        public ShopModel(BuildingsGrid grid)
        {
            ConfigProvider configProvider = new ConfigProvider();
            _buildingFactory = new BuildingFactory(configProvider);
            _prefabProvider = new PrefabProvider();

            _grid = grid;
        }

        public bool BuyBuilding(BuildingType buildingType)
        {
            Building building = _prefabProvider.GetBuilding(buildingType);
            building = building.AcceptVisitor(_buildingFactory);
            _grid.StartPlacingBuilding(building);
            return true;
        }
    }
}