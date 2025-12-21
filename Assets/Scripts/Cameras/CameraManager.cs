using Unity.Cinemachine;
using UnityEngine;
namespace Cameras
{
    public class CameraManager : ICameraManager
    {
        private Camera _mainCamera;
        private CinemachineBrain _cinemachineBrain;
        private CinemachineCamera _cinemachineCamera;
        public void Initialize()
        {
            _mainCamera = Camera.main;
            
            _cinemachineBrain = _mainCamera.GetComponent<CinemachineBrain>();
            _cinemachineCamera = _cinemachineBrain.ActiveVirtualCamera as CinemachineCamera;
            
        }

        public void FollowPlayer(Transform playerTransform)
        {
            _cinemachineCamera.Follow = playerTransform;
            _cinemachineCamera.LookAt = playerTransform;
        }

        public void UnfollowPlayer()
        {
            _cinemachineCamera.Follow = null;
            _cinemachineCamera.LookAt = null;
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