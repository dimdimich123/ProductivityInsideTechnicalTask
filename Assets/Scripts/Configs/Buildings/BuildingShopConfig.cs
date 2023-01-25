using System.Collections.Generic;
using UnityEngine;
using GameCore.BuildingResources;
using GameCore.Buildings;

namespace Configs
{
    [CreateAssetMenu(fileName = "BuildingShopConfig", menuName = "Configs/BuildingShopConfig", order = 6)]
    public class BuildingShopConfig : ScriptableObject
    {
        [SerializeField] private BuildingType _building;
        [SerializeField] private Sprite _buildingSprite;
        [SerializeField] [Multiline] private string _description;
        [SerializeField] private List<BuildingResource> _priceInResources;

        public BuildingType Building => _building;
        public Sprite BuildingSprite => _buildingSprite;
        public string Description => _description;
        public List<BuildingResource> PriceInResources => _priceInResources;
    }
}