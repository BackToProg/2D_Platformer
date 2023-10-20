using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Dust _dust;

   private bool _isAttackCoroutineRunning;
   
   private void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           Dust newDust = Instantiate(_dust, transform.position, transform.rotation);
           newDust.GetMoveDirection(_player.GetPlayerSpriteRenderer().flipX);
       }
   }
}
