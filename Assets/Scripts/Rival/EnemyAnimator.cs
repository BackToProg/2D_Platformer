using UnityEngine;

namespace Rival
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Enemy _enemy;
        
        private static readonly int IsWalk = Animator.StringToHash("IsWalk");
        private static readonly int Hit = Animator.StringToHash("Hit");
        
        private bool _isWalk;
        
        private void Start()
        {
            _enemy.Health.OnDamage += OnDamage;
        }

        private void OnDamage()
        {
            ActivateHitAnimation();
        }
        
        public void ActivateWalkAnimation(bool isAnimationActive)
        {
            _animator.SetBool(IsWalk, isAnimationActive);
        }
    
        private void ActivateHitAnimation()
        {
            _animator.SetTrigger(Hit);
        }
    }
}
