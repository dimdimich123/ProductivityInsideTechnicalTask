using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buildings
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseBuildingUI : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _buttonClose;
        [SerializeField] private Button _buttonBreake;

        public event Action OnBreake;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void OnEnable()
        {
            _buttonClose.onClick.AddListener(Close);
            _buttonBreake.onClick.AddListener(ButtonBreake);
        }

        private void ButtonBreake()
        {
            OnBreake?.Invoke();
            Close();
        }

        public void Open()
        {
            _canvasGroup.Open();
        }

        public void Close()
        {
            _canvasGroup.Close();
        }

        protected virtual void OnDisable()
        {
            _buttonClose.onClick.RemoveAllListeners();
            _buttonBreake.onClick.RemoveAllListeners();
        }
    }
}