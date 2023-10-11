using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private float _jumpForce;
    [SerializeField] private BoxCollider2D[] _groundColliders;

    private Vector3 _direction;
    private bool _isMoving = true;
    private bool _isGrounded;

    private void Update()
    {
        _isMoving = Move();
        CheckGroundTouch();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                Jump();
                _playerAnimations.ActivateJumpAnimation();
            }
        }

        _playerAnimations.ActivateWalkAnimation(_isMoving);
        _playerAnimations.ActivateJFallAnimation(IsFlying());
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
        bool isFlying;

        if (_rigidbody.velocity.y < 0)
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;
        }

        return isFlying;
    }

    private bool Move()
    {
        bool isMove = false;

        _direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _direction * (_speed * Time.deltaTime);

        if (_direction.x != 0)
        {
            _playerSpriteRenderer.flipX = !(_direction.x > 0);
            isMove = true;
        }

        return isMove;
    }
}