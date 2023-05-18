using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core.Core;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private PlayerController _playerController;
    private CharacterController _charController;

    private Vector3 _movementVelocity;
    public Vector3 MovementVelocity => _movementVelocity;
    private float _verticalVelocity;
    private Vector3 _inputVelocity;
    private float _gravity = -9.8f;

    public bool IsActiveMove { get; set; }
    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();

        _charController = GetComponent<CharacterController>();
    }
    public void SetMovementVelocity(Vector3 value)
    {
        _inputVelocity = value;
        _movementVelocity = value;
    }

    private void CalculatePlayerMovement()
    {
        //여기는 나중에
        _inputVelocity.Normalize();

        _playerAnimator?.SetMoveState(_movementVelocity); //이동속도 반영

        _movementVelocity *= _playerController.playerData.moveSpeed * Time.fixedDeltaTime;
        if (_movementVelocity.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_movementVelocity);
        }
    }

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void StopImmediately()
    {
        _movementVelocity = Vector3.zero;
        _playerAnimator?.SetMoveState(Vector3.zero); //이동속도 반영
    }
    private void FixedUpdate()
    {
        if (IsActiveMove)
        {
            CalculatePlayerMovement();
            SetRotation(MousePos);
        }

        if (_charController.isGrounded == false)
        {
            _verticalVelocity = _gravity * Time.fixedDeltaTime;
        }
        else
        {
            _verticalVelocity = _gravity * 0.3f * Time.fixedDeltaTime;
        }

        Vector3 move = _movementVelocity + _verticalVelocity * Vector3.up;
        _charController.Move(move);
        //_playerController?.SetAirbone(!_charController.isGrounded); //에어본
    }
}
