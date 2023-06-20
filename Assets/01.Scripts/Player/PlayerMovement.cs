using System.Collections;
using UnityEngine;
using static Core.Core;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isWall = false;

    private PlayerAnimator _playerAnimator;
    private PlayerController _playerController;
    private Rigidbody _rigid;

    private Transform modelTransform;

    private Vector3 _movementDir;

    private int rollDistance = 7;
    private int rollSpeed = 7;

    public Vector3 MovementDir => _movementDir;
    public bool IsActiveMove { get; set; }
    public float Speed;

    private void Awake()
    {
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();

        _rigid = GetComponent<Rigidbody>();

        modelTransform = transform.Find("Model").transform;
    }
    public void SetSpeed(float speed)
    {
        Speed = speed;
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
            if (isWall) {; break; }

            float t = elapsedTime / targetRollDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //transform.position = targetPosition;
        yield return new WaitForSeconds(0.5f);
    }
    public void PlayerOnHit(Vector3 normal, float power)
    {
        _rigid.AddForce(normal * power);
    }
    private void CalculatePlayerMovement()
    {
        _playerAnimator?.SetMoveState(_movementDir); //이동속도 반영
        transform.Translate(_movementDir.normalized *Speed * Time.deltaTime);
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
