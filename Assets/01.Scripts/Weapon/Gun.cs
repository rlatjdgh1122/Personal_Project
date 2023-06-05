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
    public UnityEvent OnStopShooting; //feedback�߰�

    private bool isShooting = false;

    public bool delayCoroutine = false;

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
        Debug.Log(isShooting);
        //�����̰� ���ٸ� �߻�
        if (isShooting && delayCoroutine == false)
        {
            Debug.Log("�����");
            //�Ѿ��� �ܷ� üũ
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
                Debug.Log("������");
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
        Debug.Log("���������");
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
