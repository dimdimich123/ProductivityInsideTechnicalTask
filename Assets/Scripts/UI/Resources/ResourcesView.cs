using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameCore.BuildingResources;

namespace UI.Resources
{
    public sealed class ResourcesView : MonoBehaviour
    {
        private Dictionary<ResourceType, ResourceDisplayer> _resourceDislayers 
            = new Dictionary<ResourceType, ResourceDisplayer>();

        private void Awake()
        {
            ResourceDisplayer[] _displayers = GetComponentsInChildren<ResourceDisplayer>();
            _resourceDislayers = _displayers.ToDictionary(x => x.Resource, y => y);
        }

        private void ChangeResourceValue(ResourceType resource, float currentValue, float maxValue)
        {
            _resourceDislayers[resource].SetResourceValue(currentValue, maxValue);
        }

        private void OnEnable()
        {
            BuildingResourceManager.OnResourceChange += ChangeResourceValue;
        }

        private void OnDisable()
        {
            BuildingResourceManager.OnResourceChange -= ChangeResourceValue;
        }
    }
}