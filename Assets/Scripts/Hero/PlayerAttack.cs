using Bullet;
using Rival;
using UnityEngine;

namespace Hero
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private DustSpawner _dustSpawner;
        
    
        private void Update()
        {
            Vector3 localScale = _player.transform.localScale;

            if (!Input.GetMouseButtonDown(0)) return;
            
            Dust newDust = _dustSpawner.Spawn(_player.transform, localScale.x);
            newDust.Init(_player, _enemy);
            newDust.DefineMoveDirection(localScale.x);
        }
    }
}