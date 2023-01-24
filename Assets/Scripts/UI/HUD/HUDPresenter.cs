using UnityEngine;

namespace UI.HUD {
    [RequireComponent(typeof(HUDView))]
    public sealed class HUDPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        private HUDView _view;
        private HUDModel _model;

        private void Awake()
        {
            _view = GetComponent<HUDView>();
            _model = new HUDModel(_cameraTransform);
        }

        private void OnEnable()
        {
            _view.OnMoveCameraX += SetCameraPoitionX;
            _view.OnMoveCameraZ += SetCameraPoitionZ;
        }

        private void SetCameraPoitionX(float value)
        {
            _model.SetCameraPositionX(value);
        }

        private void SetCameraPoitionZ(float value)
        {
            _model.SetCameraPositionZ(value);
        }

        private void OnDisable()
        {
            _view.OnMoveCameraX -= SetCameraPoitionX;
            _view.OnMoveCameraZ -= SetCameraPoitionZ;
        }
    }
}