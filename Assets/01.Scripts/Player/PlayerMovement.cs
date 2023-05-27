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

    [SerializeField]
    private int rollDistance = 5;
    [SerializeField]
    private int rollSpeed = 10;

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
        Quaternion targetRotation = Quaternion.LookRotation(_movementDir);
        modelTransform.rotation = targetRotation;
        StartCoroutine(CO_Roll());
    }
    private IEnumerator CO_Roll()
    {
        float targetRollDuration = rollDistance / rollSpeed;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + MovementDir.normalized * rollDistance;

        while (elapsedTime < targetRollDuration)
        {
            float t = elapsedTime / targetRollDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        yield return new WaitForSeconds(0.5f);
    }
    public void PlayerOnHit(Vector3 normal, float power)
    {
        _rigid.AddForce(normal * power);
    }
    private void CalculatePlayerMovement()
    {
        _playerAnimator?.SetMoveState(_movementDir); //�̵��ӵ� �ݿ�
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
        _playerAnimator?.SetMoveState(Vector3.zero); //�̵��ӵ� �ݿ�
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
