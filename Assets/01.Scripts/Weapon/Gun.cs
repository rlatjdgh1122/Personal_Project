using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : Weapon
{
    public GunDataSO gundata;
    public GameObject bullet;
    [SerializeField]
    protected Transform firePos;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting; //feedback추가

    private bool isShooting = false;

    public bool delayCoroutine = false;

    #region AMMO 관련 코드들
    protected int ammo;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Math.Clamp(value, 0, gundata.ammo);
        }
    }
    public bool AmmoFull => Ammo == gundata.ammo;
    public int EmptyBullet => gundata.ammo - ammo; //현재 부족한 탄약 수
    #endregion
    private void Awake()
    {
        ammo = gundata.ammo;
    }
    private void Update()
    {
        UseWeapon();
    }
    private void UseWeapon()
    {
        Debug.Log(isShooting);
        //딜레이가 없다면 발사
        if (isShooting && delayCoroutine == false)
        {
            Debug.Log("실행됨");
            //총알의 잔량 체크
            if (Ammo >= 0)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < gundata.bulletCount; i++)
                {
                    ShootBullet();
                }
                Ammo--;
            }
            else
            {
                Debug.Log("실행중");
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishOneShooting(); //한발 쏘고 난 다음에는 딜레이 코루틴을 돌려줘야 하기위한 함수
        }
    }
    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (gundata.autoFire == false)
        {
            Debug.Log("autoFire : " + isShooting);
            isShooting = false;
        }
    }
    private IEnumerator DelayNextShootCoroutine()
    {
        delayCoroutine = true;
        yield return new WaitForSeconds(gundata.attackDelay);
        delayCoroutine = false;
    }

    private void ShootBullet()
    {
        Debug.Log("피유우우우웅");
        SpawnBullet(firePos.position, CalculateAngle());
    }
    private Quaternion CalculateAngle()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //이부분 수정필요
        Vector3 resultPos = randomPosition * gundata.spreadAngle + transform.forward;

        Quaternion rot = Quaternion.LookRotation(resultPos);
        return rot;
    }

    private void SpawnBullet(Vector3 position, Quaternion rot)
    {
        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(position, rot);
    }

    public override void Shooting()
    {
        isShooting = true;
        Debug.Log("isShooting" + isShooting);
    }
    public override void StopShooting()
    {
        Debug.Log("1");
        isShooting = false;
        OnStopShooting?.Invoke();

    }
    public override void Reloading()
    {
        ammo = gundata.ammo;
    }
}
