using Unity.Cinemachine;
using UnityEngine;
namespace Cameras
{
    public class CameraManager : ICameraManager
    {
        private Camera _mainCamera;
        private CinemachineCamera _cinemachineCamera;
        public void Initialize(Transform playerTransform)
        {
            _mainCamera = Camera.main;
            _cinemachineCamera = _mainCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineCamera;
            _cinemachineCamera.Follow = playerTransform;
        }

        public Camera GetMainCamera()
        {
            return _mainCamera;
        }

        public Vector3 GetCameraPosition()
        {
            return _mainCamera.transform.position;
        }

        public float GetCameraWidth()
        {
            return _mainCamera.orthographicSize * _mainCamera.aspect;
        }

        public float GetOrthographicSize()
        {
            return _mainCamera.orthographicSize;
        }

        public float GetCameraAspect()
        {
            return _mainCamera.aspect;
        }
    }
}