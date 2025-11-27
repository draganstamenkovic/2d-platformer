using UnityEngine;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CircleCollider2D circleCollider;

        protected bool StopMovement { get; private set; }
        public virtual void Die()
        {
            StopMovement = true;
            animator.Play(AnimationIds.EnemyDied);
            circleCollider.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}