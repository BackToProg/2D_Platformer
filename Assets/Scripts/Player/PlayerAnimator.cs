using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isWalk;
    private bool _isFlying;
    
    private static readonly int IsWalk = Animator.StringToHash("IsWalk");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int IsFlying = Animator.StringToHash("IsFlying");

    public void ActivateWalkAnimation(bool isAnimationActive)
    {
        _animator.SetBool(IsWalk, isAnimationActive);
    }

    public void ActivateJumpAnimation()
    {
        _animator.SetTrigger(Jump);
    }
    
    public void ActivateJFallAnimation(bool isAnimationActive)
    {
        _animator.SetBool(IsFlying, isAnimationActive);
    }
}
