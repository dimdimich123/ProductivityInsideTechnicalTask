using UI.Buildings;

namespace GameCore.Buildings.Upgradable
{
    public class UpgradableBuildingController : BaseBuildingController
    {
        private IUpgradable _upgradableBuilding;
        private UpgradableBuildingUI _ui;

        private void Awake()
        {
            _upgradableBuilding = _building as IUpgradable;
            _ui = _buildingUI as UpgradableBuildingUI;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            if(_ui != null)
            {
                _ui.OnUpgrade += Upgrade;
            }
        }

        private void Upgrade()
        {
            if(_upgradableBuilding != null)
            {
                _upgradableBuilding.Upgrade();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_ui != null)
            {
                _ui.OnUpgrade -= Upgrade;
            }
        }
    }
}