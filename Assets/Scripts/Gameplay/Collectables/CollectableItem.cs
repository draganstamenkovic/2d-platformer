using System;
using DG.Tweening;
using Message.Messages;
using UnityEngine;

namespace Gameplay.Collectables
{
    public class CollectableItem : MonoBehaviour
    {
        public CollectableType itemType;
        public Vector3 Position => transform.position;
        public void OnCollected()
        {
            Destroy(gameObject);
        }
    }
}