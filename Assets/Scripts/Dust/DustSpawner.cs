using UnityEngine;

namespace Dust
{
    public class DustSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDeltaPosition;
        [SerializeField] private Dust _template;

        public Dust Spawn(Transform objectTransform, bool objectFlipX)
        {
            Vector2 spawnPosition = DefineSpawnPosition(objectFlipX, objectTransform);
            return Instantiate(_template, spawnPosition, objectTransform.rotation);
        }

        private Vector2 DefineSpawnPosition(bool objectFlipX, Transform objectTransform)
        {
            int moveRight = 1;
            int moveLeft = -1;
            Vector2 spawnPosition;
        
            if (objectFlipX)
            {
                spawnPosition = new Vector2(objectTransform.position.x + (_spawnDeltaPosition * moveLeft), objectTransform.position.y);
            }
            else
            {
                spawnPosition = new Vector2(objectTransform.position.x + (_spawnDeltaPosition * moveRight), objectTransform.position.y);
            }

            return spawnPosition;
        }
    }
}
