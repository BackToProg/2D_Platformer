using UnityEngine;

namespace Dust
{
    public class DustMover : MonoBehaviour
    {
        private int GetDirection(bool objectFlip)
        {
            int moveRight = 1;
            int moveLeft = -1;
        
            if (objectFlip)
            {
                return moveLeft;
            }

            return moveRight;
        }

        public void Move(float speed, bool objectFlip)
        {
            int direction = GetDirection(objectFlip);
        
            transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0));
        }
    }
}
