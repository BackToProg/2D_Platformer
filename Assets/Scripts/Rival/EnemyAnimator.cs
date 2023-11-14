using UnityEngine;

namespace Rival
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsWalk = Animator.StringToHash("IsWalk");
        private static readonly int Hit = Animator.StringToHash("Hit");
        
        private bool _isWalk;
        
        public void ActivateWalkAnimation(bool isAnimationActive)
        {
            _animator.SetBool(IsWalk, isAnimationActive);
        }
    
        public void ActivateHitAnimation()
        {
            _animator.SetTrigger(Hit);
        }
    }
}
