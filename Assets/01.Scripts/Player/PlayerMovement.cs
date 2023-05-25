using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core.Core;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private PlayerController _playerController;
    private CharacterController _charController;

    private Transform modelTransform;

    private Vector3 _movementVelocity;
    public Vector3 MovementVelocity => _movementVelocity;
    private Vector3 _inputVelocity;
    private float _verticalVelocity;
    private float _gravity = -9.8f;
    public bool IsActiveMove { get; set; }
    private void Awake()
    {
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();

        _charController = GetComponent<CharacterController>();

        modelTransform = transform.Find("Model").transform;
    }
    public void SetMovementDirection(Vector3 value)
    {
        //_movementVelocity = dir;
        _inputVelocity = value;
        _movementVelocity = value;
    }

    private void CalculatePlayerMovement()
    {
        /*_playerAnimator?.SetMoveState(_movementVelocity); //이동속도 반영
        transform.Translate(_movementVelocity * _playerController.playerData.Speed * Time.deltaTime);*/

        Debug.Log(_movementVelocity);
        _playerAnimator?.SetMoveState(_movementVelocity.normalized); //이동속도 반영

        _movementVelocity *= _playerController.playerData.Speed * Time.fixedDeltaTime;
    }

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        modelTransform.rotation = targetRotation;
        //modelTransform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 30 * Time.deltaTime);
    }

    public void StopImmediately()
    {
        _movementVelocity = Vector3.zero;
        _playerAnimator?.SetMoveState(Vector3.zero); //이동속도 반영
    }
    private void FixedUpdate()
    {
       /* if (IsActiveMove)
        {
            CalculatePlayerMovement();
            SetRotation(MousePos);
        }*/

        if (IsActiveMove)
        {
            CalculatePlayerMovement();
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
    }
}
