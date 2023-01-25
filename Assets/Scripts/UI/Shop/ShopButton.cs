using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCore.BuildingResources;

namespace UI.Shop
{
    public sealed class ShopButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private TMPro.TMP_Text _descrition;
        [SerializeField] private TMPro.TMP_Text _price;

        public Button Button => _button;

        public void Init(Sprite sprite, string descriptionText, List<BuildingResource> priceInResources)
        {
            _image.sprite = sprite;
            _descrition.text = descriptionText;

            string text = string.Empty;
            foreach (BuildingResource resource in priceInResources)
            {
                text += resource.Resource.ToString() + " - " + resource.Value + "\n";
            }
            _price.text = text;
        }
    }
}