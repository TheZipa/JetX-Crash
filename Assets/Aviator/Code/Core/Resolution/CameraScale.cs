using UnityEngine;

namespace Aviator.Code.Core.Resolution
{
    public class CameraScale : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _iPadSize;
        [SerializeField] private float _iPhoneSize;

        private void Start() =>
            _camera.orthographicSize = Screen.width > 1500 
                ? _iPadSize 
                : _iPhoneSize;
    }
}