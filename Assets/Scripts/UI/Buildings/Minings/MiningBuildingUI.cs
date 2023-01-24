using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buildings.Minings
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MiningBuildingUI : MonoBehaviour, IPanel
    {
        [SerializeField] private Image _timeFilledImage;
        [SerializeField] private Button _getResourcesButton;

        private CanvasGroup _canvasGroup;

        public event Action OnGetResourcesButton;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _getResourcesButton.onClick.AddListener(GetResources);
        }

        public void SetButtonInteractive()
        {
            _getResourcesButton.interactable = !_getResourcesButton.interactable;
        }

        public void GetResources()
        {
            OnGetResourcesButton?.Invoke();
            SetButtonInteractive();
            SetTime(0);
        }

        public void SetTime(float percent)
        {
            _timeFilledImage.fillAmount = percent;
        }

        public void Open()
        {
            _canvasGroup.Open();
        }

        public void Close()
        {
            _canvasGroup.Close();
        }

        private void OnDisable()
        {
            _getResourcesButton.onClick.RemoveAllListeners();
        }
    }
}