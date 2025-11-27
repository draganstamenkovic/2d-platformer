using Configs;
using UnityEngine;
using DG.Tweening;

namespace Gameplay.Enemies
{
    public class Vulture : Enemy
    {
        [SerializeField] private Transform vultureTransform;
        [SerializeField] private Transform startPointTransform;
        [SerializeField] private Transform endPointTransform;
        [SerializeField] private EnemiesConfig enemiesConfig;
        
        private void Start()
        {
            Move();
        }

        public override void Die()
        {
            // Kill all tweens on this transform
            vultureTransform.DOKill();
            base.Die();
        }

        private void Move()
        {
            if (StopMovement) return;
            
            vultureTransform.DOMove(endPointTransform.position, enemiesConfig.vultureMoveDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    if (StopMovement) return;
                    
                    vultureTransform.localScale = new Vector3(-1, 1, 1);
                    vultureTransform.DOMove(startPointTransform.position, enemiesConfig.vultureMoveDuration)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => 
                        { 
                            if (StopMovement) return;
                            
                            vultureTransform.localScale = Vector3.one;
                            Move();
                        });
                });
        }
    }
}
