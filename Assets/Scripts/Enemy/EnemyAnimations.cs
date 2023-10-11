using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private bool _isWalk;
    private static readonly int IsWalk = Animator.StringToHash("IsWalk");
    
    private void Update()
    {
        _animator.SetBool(IsWalk, _isWalk);
    }
    
    public void ActivateWalkAnimation(bool isAnimationActive)
    {
        _isWalk = isAnimationActive;
    }
}
