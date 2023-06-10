using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovementInput : MonoBehaviour
{
    [SerializeField] private float _moveForce = 30.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _maxSpeed = 5.0f;
    [SerializeField] private ChangeColor _crouchColorMethod;
    [SerializeField] private GroundCheck _groundCheckMethod;

    private bool _isGrounded = false;
    private Rigidbody2D _playerBody;
    private float _moveForceControl;
    private float _jumpForceControl;
    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        IsOnTheGround();
        GiveMoveForce();
        GiveJumpForce();
    }

    public void Move()
    {
        _moveForceControl = Input.GetAxis("Horizontal");
    }
    public void Jump()
    {
        _jumpForceControl = Input.GetAxis("Vertical");
    }

    private void GiveMoveForce()
    {
        _playerBody.AddForce(Vector3.right * _moveForceControl * _moveForce);
    }

    private void GiveJumpForce()
    {
        if (_isGrounded)
        {
            _playerBody.AddForce(Vector2.up * _jumpForce *_jumpForceControl, ForceMode2D.Impulse);

            if (_playerBody.velocity.magnitude > _maxSpeed)
            {
                _playerBody.velocity = _playerBody.velocity.normalized * _maxSpeed;
            }
        }
    }

    public void Crouch()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            _crouchColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.Crouch);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _crouchColorMethod.ChangeObjectColor(ChangeColor.ColorStatements.Idle);
        }
    }
    private void IsOnTheGround()
    {
        _isGrounded = _groundCheckMethod.IsOnGround();
    }


}
