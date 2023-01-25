using UnityEngine;
using UnityEngine.EventSystems;
using UI.Buildings;


namespace GameCore.Buildings
{
    public class BaseBuildingController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected BaseBuildingUI _buildingUI;
        [SerializeField] protected Building _building;

        protected virtual void OnEnable()
        {
            _buildingUI.OnBreake += BreakeBuilding;
        }

        private void BreakeBuilding()
        {
            _building.Breake();
        }

        protected virtual void OnDisable()
        {
            _buildingUI.OnBreake -= BreakeBuilding;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _buildingUI.Open();
        }
    }
}