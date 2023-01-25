using GameCore.Buildings;
using UnityEngine;
using UnityEngine.EventSystems;


namespace GameCore.Grid
{
    public sealed class BuildingsGrid : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler
    {
        [SerializeField] private Vector2Int _gridSize = new Vector2Int(30, 30);

        private Building[,] _grid;
        private Building _flyingBuilding;
        private Transform _flyingBuildingTransform;

        private bool _available = false;
        private int _x;
        private int _y;

        private void Awake()
        {
            _grid = new Building[_gridSize.x, _gridSize.y];
        }

        public void StartPlacingBuilding(Building buildingPrefab)
        {
            if (_flyingBuilding != null)
            {
                Destroy(_flyingBuilding.gameObject);
            }

            _flyingBuilding = buildingPrefab;
            _flyingBuildingTransform = _flyingBuilding.transform;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (_flyingBuilding != null)
            {
                _x = Mathf.RoundToInt(eventData.pointerCurrentRaycast.worldPosition.x);
                _y = Mathf.RoundToInt(eventData.pointerCurrentRaycast.worldPosition.z);

                _available = true;

                if (_x < 0 || _x > _gridSize.x - _flyingBuilding.Size.x) _available = false;
                if (_y < 0 || _y > _gridSize.y - _flyingBuilding.Size.y) _available = false;

                if (_available && IsPlaceTaken(_x, _y))
                {
                    _available = false;
                }

                _flyingBuildingTransform.position = new Vector3(_x, 0, _y);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_flyingBuilding != null && _available)
            {
                PlaceFlyingBuilding(_x, _y);
            }
        }

        private bool IsPlaceTaken(int placeX, int placeY)
        {
            for (int x = 0; x < _flyingBuilding.Size.x; x++)
            {
                for (int y = 0; y < _flyingBuilding.Size.y; y++)
                {
                    if (_grid[placeX + x, placeY + y] != null) return true;
                }
            }

            return false;
        }

        private void PlaceFlyingBuilding(int placeX, int placeY)
        {
            for (int x = 0; x < _flyingBuilding.Size.x; x++)
            {
                for (int y = 0; y < _flyingBuilding.Size.y; y++)
                {
                    _grid[placeX + x, placeY + y] = _flyingBuilding;
                }
            }

            _flyingBuilding.StartBuild();
            _flyingBuilding = null;
        }
    }
}