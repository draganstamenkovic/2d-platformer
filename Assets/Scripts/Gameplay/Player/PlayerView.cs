using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerView : MonoBehaviour
    {
        public Rigidbody2D rigidBody;
        public Animator animator;
        
        [Header("Ground Detection")]
        public Transform groundCheck;
        
        public Action<Collision2D> OnCollision;
        public void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision?.Invoke(other);
        }
    }
}