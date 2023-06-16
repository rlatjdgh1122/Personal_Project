using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : Weapon
{
    public GunDataSO gunData;
    public GameObject bullet;
    [SerializeField]
    protected Transform firePos;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting; //feedback�߰�

    private bool _isShooting = false;
    public bool delayCoroutine = false;

    #region AMMO ���� �ڵ��
    protected int ammo;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Math.Clamp(value, 0, gunData.ammocapacity);
        }
    }
    public bool AmmoFull => Ammo == gunData.ammocapacity;
    public int EmptyBullet => gunData.ammocapacity - ammo; //���� ������ ź�� ��
    #endregion
    private void Awake()
    {
        Ammo = gunData.ammocapacity;
    }
    private void Update()
    {
        UseWeapon();
    }   
    private void UseWeapon()
    {
        //�����̰� ���ٸ� �߻�
        Debug.Log($"update : {_isShooting}, {transform.name}"); //���������� ��� ����װ� false��.
        if (_isShooting == true && delayCoroutine == false)
        {
            Debug.Log("asdf");
            //�Ѿ��� �ܷ� üũ
            if (Ammo > 0)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < gunData.bulletCount; i++)
                {
                    ShootBullet();
                }
                Ammo--;
            }
            else
            {
                _isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishOneShooting(); //�ѹ� ��� �� �������� ������ �ڷ�ƾ�� ������� �ϱ����� �Լ�
        }
    }
    private void FinishOneShooting()
    {
        Debug.Log("FinishOneShooting");
        StartCoroutine(DelayNextShootCoroutine());
        if (gunData.autoFire == false)
        {
            _isShooting = false;
        }
    }
    private IEnumerator DelayNextShootCoroutine()
    {
        Debug.Log("DelayNextShootCoroutine");
        delayCoroutine = true;
        yield return new WaitForSeconds(gunData.attackDelay);
        delayCoroutine = false;
    }

    private void ShootBullet()
    {
        Debug.Log("ShootBullet");
        SpawnBullet(firePos.position, CalculateAngle());
    }

    private Quaternion CalculateAngle()
    {
        Debug.Log("CalculateAngle");
        Vector3 randomPosition = Random.insideUnitSphere; //�̺κ� �����ʿ�
        Vector3 resultPos = randomPosition * gunData.spreadAngle + transform.forward;

        Quaternion rot = Quaternion.LookRotation(resultPos);
        return rot;
    }

    private void SpawnBullet(Vector3 position, Quaternion rot)
    {
        Debug.Log("SpawnBullet");
        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(position, rot);
    }

    public override void Shooting()
    {
        _isShooting = true;
        Debug.Log($"Shooting : {_isShooting} {transform.name}");
    }
    public override void StopShooting()
    {

        _isShooting = false;
        Debug.Log("StopShooting : " + _isShooting);
        OnStopShooting?.Invoke();

    }
    public override void Reloading()
    {
        Debug.Log("�Ѿ� ����");
        Ammo = gunData.ammocapacity;
    }
}
