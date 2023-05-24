using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core.Core;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private PlayerController _playerController;
    //private CharacterController _charController;

    private Vector3 _movementDir;
    public Vector3 MovementVelocity => _movementDir;
    private Transform modelPos;

    public bool IsActiveMove { get; set; }
    private void Awake()
    {
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();

        //_charController = GetComponent<CharacterController>();

        modelPos = transform.Find("Model").transform;
    }
    public void SetMovementDirection(Vector3 dir)
    {
        _movementDir = dir;
    }

    private void CalculatePlayerMovement()
    {
        _playerAnimator?.SetMoveState(_movementDir); //이동속도 반영
        transform.Translate(_movementDir * _playerController.playerData.Speed * Time.deltaTime);
    }

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - modelPos.position;
        dir.y = 0;
        modelPos.rotation = Quaternion.LookRotation(dir);
    }

    public void StopImmediately()
    {
        _movementDir = Vector3.zero;
        _playerAnimator?.SetMoveState(Vector3.zero); //이동속도 반영
    }
    private void Update()
    {
        if (IsActiveMove)
        {
            CalculatePlayerMovement();
            SetRotation(MousePos.normalized);
        }
    }
}
