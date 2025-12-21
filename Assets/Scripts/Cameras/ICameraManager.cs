using UnityEngine;

namespace Cameras
{
    public interface ICameraManager
    {
        void Initialize();
        Camera GetMainCamera();
        Vector3 GetCameraPosition();
        void FollowPlayer(Transform playerTransform);
        void UnfollowPlayer();
        float GetCameraWidth();
        float GetOrthographicSize();
        float GetCameraAspect();
    }
}