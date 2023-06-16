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
    public UnityEvent OnStopShooting; //feedback추가

    [SerializeField]
    private bool _isShooting = false;

    public bool delayCoroutine = false;

    #region AMMO 관련 코드들
    [SerializeField]
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
    public int EmptyBullet => gunData.ammocapacity - ammo; //현재 부족한 탄약 수
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
        if (_isShooting == true && delayCoroutine == false)
        {
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
            FinishOneShooting();
        }
    }
    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (gunData.autoFire == false)
        {
            _isShooting = false;
        }
    }
    private IEnumerator DelayNextShootCoroutine()
    {
        delayCoroutine = true;
        Debug.Log(gunData.attackDelay);
        yield return new WaitForSecondsRealtime(gunData.attackDelay);
        delayCoroutine = false;
        Debug.Log(delayCoroutine);
    }

    private void ShootBullet()
    {
        SpawnBullet(firePos.position, CalculateAngle());
    }

    private Quaternion CalculateAngle()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //이부분 수정필요
        Vector3 resultPos = randomPosition * gunData.spreadAngle + transform.forward;

        Quaternion rot = Quaternion.LookRotation(resultPos);
        return rot;
    }

    private void SpawnBullet(Vector3 position, Quaternion rot)
    {
        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.Set_P_Damage(gunData.damage);
        b.SetPositionAndRotation(position, rot);
    }

    public override void Shooting()
    {
        _isShooting = true;
    }
    public override void StopShooting()
    {

        _isShooting = false;
        OnStopShooting?.Invoke();

    }
    public override void Reloading()
    {
        Ammo = gunData.ammocapacity;
    }
}