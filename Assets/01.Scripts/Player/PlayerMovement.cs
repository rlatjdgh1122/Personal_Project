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
    private Rigidbody _rigid;

    private Transform modelTransform;

    private Vector3 _movementDir;
    public Vector3 MovementDir => _movementDir;
    public bool IsActiveMove { get; set; }
    private void Awake()
    {
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();

        _rigid = GetComponent<Rigidbody>();

        modelTransform = transform.Find("Model").transform;
    }
    public void SetMovementDirection(Vector3 dir)
    {
        _movementDir = dir;
    }
    public void PlayerToRoll()
    {
        Debug.Log("qwer");
        SetRotation(_movementDir);
        _rigid.AddForce(_movementDir * 30);
    }
    public void PlayerOnHit(Vector3 normal, float power)
    {
        _rigid.AddForce(normal * power);
    }
    private void CalculatePlayerMovement()
    {
        _playerAnimator?.SetMoveState(_movementDir); //이동속도 반영
        transform.Translate(_movementDir.normalized * _playerController.playerData.Speed * Time.deltaTime);
    }
    private void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        modelTransform.rotation = targetRotation;
    }

    public void StopImmediately()
    {
        _movementDir = Vector3.zero;
        _playerAnimator?.SetMoveState(Vector3.zero); //이동속도 반영
    }
    private void FixedUpdate()
    {
        if (IsActiveMove)
        {
            CalculatePlayerMovement();
            SetRotation(MousePos);
        }
    }
}
