using UnityEngine;
using UI.Buildings.Minings;

namespace GameCore.Buildings.Minings
{
    public class MiningBuildingController : MonoBehaviour
    {
        [SerializeField] private MiningBuildingUI _miningUI;
        [SerializeField] private MiningBuilding _miningBuilding;

        private void OnEnable()
        {
            _miningBuilding.OnSecondHasPassed += UpdateTimeUI;
            _miningBuilding.OnMiningEnd += SetButtonInteractive;
            _miningUI.OnGetResourcesButton += GetResources;
            _miningBuilding.OnBuilt += OpenMiningPanel;
        }

        private void SetButtonInteractive()
        {
            _miningUI.SetButtonInteractive();
        }

        private void UpdateTimeUI(float percent)
        {
            _miningUI.SetTime(percent);
        }
        
        private void OpenMiningPanel()
        {
            _miningUI.Open();
        }

        private void GetResources()
        {
            _miningBuilding.GetResources();
        }

        private void OnDisable()
        {
            _miningBuilding.OnSecondHasPassed -= UpdateTimeUI;
            _miningBuilding.OnMiningEnd -= SetButtonInteractive;
            _miningUI.OnGetResourcesButton -= GetResources;
            _miningBuilding.OnBuilt -= OpenMiningPanel;
        }
    }
}