using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buildings
{
    public class UpgradableBuildingUI : BaseBuildingUI
    {
        [SerializeField] private Button _buttonUpgrade;

        public event Action OnUpgrade;

        protected override void OnEnable()
        {
            base.OnEnable();
            _buttonUpgrade.onClick.AddListener(Upgrade);
        }

        private void Upgrade()
        {
            OnUpgrade?.Invoke();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _buttonUpgrade.onClick.RemoveAllListeners();
        }
    }
}