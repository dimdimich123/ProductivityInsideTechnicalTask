using GameCore.Buildings;
using GameCore.Buildings.Minings;
using GameCore.Buildings.Upgradable;
using GameCore.Buildings.Acceleratings;
using GameCore.Buildings.Storages;

namespace Infrastructure.CommonLogic
{
    public interface IVisitor
    {
        public Building Visit(Building building);
        public Building Visit(MiningBuilding building);
        public Building Visit(UpgradableMiningBuilding building);
        public Building Visit(StorageBuilding building);
        public Building Visit(UpgradableStorageBuilding building);
        public Building Visit(AcceleratingBuilding building);
    }
}