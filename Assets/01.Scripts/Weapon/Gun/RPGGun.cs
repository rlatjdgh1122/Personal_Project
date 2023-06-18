using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPGGun : Weapon
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
    protected override void Awake()
    {
        base.Awake();
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
                    Debug.Log("공격");
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
        yield return new WaitForSecondsRealtime(gunData.attackDelay);
        delayCoroutine = false;
    }

    private void ShootBullet()
    {
        //SpawnBullet(firePos.position, CalculateAngle());
    }

    private void SpawnBullet(Vector3 position, Vector3 rot)
    {
        BoomBullet b = PoolManager.Instance.Pop(bullet.name) as BoomBullet;

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
