using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponDataSO : ScriptableObject
{
    [Range(15f, 70f)]
    public int damage; //������
    [Range(.1f, 1f)]
    public float attackDelay; //���� ������
    [Range(.5f, 3f)]
    public float stunDuration; //���� �ð�
    [Range(10f, 50f)]
    public float knockBack; //�˹�
    [Range(.5f, 3f)]
    public float weight; //����
    [Range(7f, 30f)]
    public int UseStamina; //����ϴ� ���¹̳�
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;
}
