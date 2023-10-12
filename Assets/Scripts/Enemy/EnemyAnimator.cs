using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private bool _isWalk;
    private static readonly int IsWalk = Animator.StringToHash("IsWalk");
    
    public void ActivateWalkAnimation(bool isAnimationActive)
    {
        _animator.SetBool(IsWalk, isAnimationActive);
    }
}
