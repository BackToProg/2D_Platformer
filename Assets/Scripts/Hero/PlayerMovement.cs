using UnityEngine;

namespace Hero
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private float _jumpForce;
        [SerializeField] private BoxCollider2D[] _groundColliders;

        private Vector3 _direction;
        private bool _isMoving = true;
        private bool _isGrounded;
        private Vector3 _positiveScaleX = new Vector3(1, 1, 1);
        private Vector3 _negativeScaleX = new Vector3(-1, 1, 1);

        private void Update()
        {
            _isMoving = Move();
            CheckGroundTouch();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isGrounded)
                {
                    Jump();
                    _playerAnimator.ActivateJumpAnimation();
                }
            }

            _playerAnimator.ActivateWalkAnimation(_isMoving);
            _playerAnimator.ActivateJFallAnimation(IsFlying());
        }

        private void Jump()
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void CheckGroundTouch()
        {
            float rayLenght = 0.3f;
            Vector2 rayStartPosition = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector2.down, rayLenght);

            if (hit.collider != null)
            {
                foreach (var groundCollider in _groundColliders)
                {
                    _isGrounded = hit.collider.IsTouching(groundCollider);

                    if (_isGrounded)
                    {
                        break;
                    }
                }
            }
            else
            {
                _isGrounded = false;
            }
        }

        private bool IsFlying()
        {
            bool isFlying = _rigidbody.velocity.y < 0;

            return isFlying;
        }

        private bool Move()
        {
            bool isMove = false;
            _direction = new Vector2(Input.GetAxis("Horizontal"), 0);
            
            transform.position += _direction * (_player.MovementSpeed * Time.deltaTime);

            if (_direction.x != 0)
            {
                _player.transform.localScale = _direction.x > 0 ? _positiveScaleX : _negativeScaleX;
                isMove = true;
            }

            return isMove;
        }
    }
}