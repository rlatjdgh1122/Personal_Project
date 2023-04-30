using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GunData gundata;
    [SerializeField]
    protected Transform firePos;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting;
    public UnityEvent<int> OnChangeAmmo;
    protected bool isShooting;
    protected bool delayCoroutine = false;

    #region AMMO ���� �ڵ��
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
    public int EmptyBullet => gundata.ammo - ammo; //���� ������ ź�� ��
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
        //�����̰� ���ٸ� �߻�
        if (isShooting && delayCoroutine == false)
        {
            //�Ѿ��� �ܷ� üũ
            if (Ammo >= gundata.bulletCount)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < gundata.bulletCount; i++)
                {
                    ShootBullet();
                    Ammo--;
                    OnChangeAmmo?.Invoke(ammo);
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishOneShooting(); //�ѹ� ��� �� �������� ������ �ڷ�ƾ�� ������� �ϱ����� �Լ�
        }

    }

    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (gundata.autoFire == false)
        {
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
        SpawnBullet(firePos.position, CalculateAngle());
    }

    private Quaternion CalculateAngle()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //�̺κ� �����ʿ�
        Vector3 resultPos = randomPosition * gundata.spreadAngle + transform.forward;

        Quaternion rot = Quaternion.LookRotation(resultPos);
        return rot;
    }

    private void SpawnBullet(Vector3 position, Quaternion rot)
    {
        RegularBullet b = PoolManager.Instance.Pop("Bullet") as RegularBullet;
        b.SetPositionAndRotation(position, rot);
    }

    public void TryShooting()
    {
        isShooting = true;
    }
    public void StopShooting()
    {
        isShooting = false;
        OnStopShooting?.Invoke();

    }
}
