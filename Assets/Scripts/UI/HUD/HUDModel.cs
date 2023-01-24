using UnityEngine;

namespace UI.HUD
{
    public sealed class HUDModel
    {
        private Transform _cameraTransform;
        private Vector3 _position;

        public HUDModel(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform;
            _position = _cameraTransform.position;
        }

        public void SetCameraPositionX(float value)
        {
            _position.x = value;
            _cameraTransform.position = _position;
        }

        public void SetCameraPositionZ(float value)
        {
            _position.z = value;
            _cameraTransform.position = _position;
        }
    }
}