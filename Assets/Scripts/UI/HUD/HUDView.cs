using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
    public sealed class HUDView : MonoBehaviour
    {
        [SerializeField] private Button _openShopButton;
        [SerializeField] private Slider _moveCameraXSlider;
        [SerializeField] private Slider _moveCameraZSlider;

        public event Action OnOpenShop;
        public event Action<float> OnMoveCameraX;
        public event Action<float> OnMoveCameraZ;

        private void OnEnable()
        {
            _openShopButton.onClick.AddListener(OpenShop);
            _moveCameraXSlider.onValueChanged.AddListener(SetCameraPositionX);
            _moveCameraZSlider.onValueChanged.AddListener(SetCameraPositionZ);
        }

        private void OpenShop()
        {
            OnOpenShop?.Invoke();
        }

        private void SetCameraPositionX(float value)
        {
            OnMoveCameraX?.Invoke(value);
        }

        private void SetCameraPositionZ(float value)
        {
            OnMoveCameraZ?.Invoke(value);
        }

        private void OnDisable()
        {
            _openShopButton.onClick.RemoveAllListeners();
            _moveCameraXSlider.onValueChanged.RemoveAllListeners();
            _moveCameraZSlider.onValueChanged.RemoveAllListeners();
        }
    }
}