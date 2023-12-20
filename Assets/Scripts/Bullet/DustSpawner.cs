using UnityEngine;

namespace Bullet
{
    public class DustSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDeltaPosition;
        [SerializeField] private Dust _template;

        public Dust Spawn(Transform dustTransform, float scale)
        {
            Vector2 spawnPosition = DefineSpawnPosition(scale, dustTransform);
            return Instantiate(_template, spawnPosition, dustTransform.rotation);
        }

        private Vector2 DefineSpawnPosition(float scale, Transform dustTransform)
        {
            Vector2 spawnPosition = new Vector2(dustTransform.position.x + (_spawnDeltaPosition * scale),
                dustTransform.position.y);

            return spawnPosition;
        }
    }
}