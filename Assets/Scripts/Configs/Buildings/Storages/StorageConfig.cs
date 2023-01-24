using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Storages
{
    [CreateAssetMenu(fileName = "StorageConfig", menuName = "Configs/StorageConfig", order = 3)]
    public class StorageConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private StorageLevelConfig _config;

        public BuildingType BuildingType => _buildingType;
        public StorageLevelConfig Config => _config;
    }
}