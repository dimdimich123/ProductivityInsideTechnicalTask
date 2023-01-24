using UnityEngine;
using GameCore.BuildingResources;

namespace UI.Resources
{
    public sealed class ResourceDisplayer : MonoBehaviour
    {
        [SerializeField] private ResourceType _resource;
        [SerializeField] private TMPro.TMP_Text _text;

        public ResourceType Resource => _resource;

        public void SetResourceValue(float currentValue, float maxValue)
        {
            _text.text = currentValue.ToString() + "/" + maxValue.ToString();
        }
    }
}