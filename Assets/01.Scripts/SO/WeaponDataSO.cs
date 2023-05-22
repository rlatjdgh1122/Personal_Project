using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponDataSO : ScriptableObject
{
    public string WeaponName; // ���� ����
    public Sprite image; //���� �̹���
    public float damage; //������
    public float attackDelay; //���� ������
    public float stunDuration; //���� �ð�
    public float knockBack; //�˹�
    public float weight; //����
    public int UseStamina; //����ϴ� ���¹̳�
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;

    public void Awake()
    {
        
    }
}
