using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : Weapon
{
    public GunDataSO gunData;
    public GameObject bullet;
    [SerializeField]
    protected Transform firePos;
    protected GameObject pt => transform.Find("Paticle").gameObject;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting; //feedback추가

    [SerializeField]
    private bool _isShooting = false;

    public bool delayCoroutine = false;

    private Coroutine delayCorou = null;
    #region AMMO 관련 코드들
    [SerializeField]
    protected int ammo;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Math.Clamp(value, -1, gunData.ammocapacity);
        }
    }
    public bool AmmoFull => Ammo == gunData.ammocapacity;
    public int EmptyBullet => gunData.ammocapacity - ammo; //현재 부족한 탄약 수
    #endregion
    protected override void Awake()
    {
        base.Awake();
        Ammo = gunData.ammocapacity;
        pt.SetActive(false);
    }
    protected void OnEnable()
    {
        delayCoroutine = false;
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
            if (Ammo >= 0)
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
        if (delayCorou != null)
        {
            StopCoroutine(delayCorou);
        }

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
        SpawnBullet();
        SoundManager.Instance.PlayerSoundName(playerSoundName);
        SignalHub.OnModifyBulletCount?.Invoke(Ammo, gunData.ammocapacity);

        pt.SetActive(true);
        Invoke("Hiden_Particle", .1f);
    }
    private void Hiden_Particle()
    {
        pt.SetActive(false);
    }

    protected virtual void SpawnBullet()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //이부분 수정필요
        Vector3 resultPos = randomPosition * gunData.spreadAngle + transform.forward;

        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.Set_P_Damage(gunData.damage);
        b.SetPositionAndRotation(firePos.position, Quaternion.LookRotation(resultPos));
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
        SignalHub.OnModifyBulletCount.Invoke(Ammo, gunData.ammocapacity);
    }
}