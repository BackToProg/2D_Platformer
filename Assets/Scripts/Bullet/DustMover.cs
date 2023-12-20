using UnityEngine;

namespace Bullet
{
    public class DustMover : MonoBehaviour
    {
        public void Move(float speed, float direction)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0));
        }
    }
}
