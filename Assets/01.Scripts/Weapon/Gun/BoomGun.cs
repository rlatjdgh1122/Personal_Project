using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BoomGun : Weapon
{
    public GunDataSO gunData;
    public GameObject bullet;
    [SerializeField]
    protected Transform firePos;
    private GameObject pt => transform.Find("Paticle").gameObject;

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
    private void OnEnable()
    {
        Hiden_Particle();
        if (gunData.animController != null)
        {
            animatorController.runtimeAnimatorController = gunData.animController;
        }
        else if (gunData.animController == null)
        {
            animatorController.runtimeAnimatorController = GameManager.Instance.defalutAnim;
        }
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
        yield return new WaitForSecondsRealtime(gunData.attackDelay);
        delayCoroutine = false;
    }

    private void ShootBullet()
    {
        pt.SetActive(true);
        SoundManager.Instance.PlayerSoundName(playerSoundName);
        Invoke("Hiden_Particle", .1f);
        SpawnBullet(firePos.position, transform.right);
    }
    private void Hiden_Particle()
    {
        pt.SetActive(false);
    }

    private void SpawnBullet(Vector3 position, Vector3 dir)
    {
        BoomBullet b = PoolManager.Instance.Pop(bullet.name) as BoomBullet;
        b.SetDamage(gunData.damage);
        b.SetPositionAndShoot(position, dir);
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
