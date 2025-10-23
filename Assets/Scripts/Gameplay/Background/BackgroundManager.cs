using Configs;
using UnityEngine;
using VContainer;

namespace Gameplay.Background
{
    public class BackgroundManager : MonoBehaviour
    {
        [Inject] private readonly BackgroundConfig _config;

        [SerializeField] private Transform forestTransform;
        [SerializeField] private Transform skyTransform;
        private Vector3 _cameraPosition;
        /*
        private void Update()
        {
            skyTransform.transform.position = _cameraPosition;
        }
        */
    }
}