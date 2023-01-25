using UnityEngine;
using GameCore.Buildings;

namespace Configs.Buildings.Storages
{
    [CreateAssetMenu(fileName = "StorageConfig", menuName = "Configs/StorageConfig", order = 3)]
    public class StorageConfig : BuildingConfig
    {
        [SerializeField] private StorageLevelConfig _config;

        public StorageLevelConfig Config => _config;
    }
}