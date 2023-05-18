using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Core
{
    public enum StateType
    {
        Normal = 0,
        Attack = 1,
        OnHit = 2,
        Rolling = 3,
    }
    public class Core
    {
        private static Camera _mainCam = null;
        public static Camera Cam
        {
            get
            {
                if (_mainCam == null)
                    _mainCam = Camera.main;
                return _mainCam;
            }
        }
        private static Transform playerPos;
        public static Transform PlayerPos
        {
            get
            {
                if (playerPos == null)
                    playerPos = GameObject.Find("Player").transform;
                return playerPos;
            }
        }
        private static Vector3 dirMouse;
        public static Vector3 DirMouse
        {
            get
            {
                return (Cam.transform.position - playerPos.position).normalized;
            }
        }
        public static Animator Anim
        {
            get
            {
                if (anim == null)
                    anim = GameObject.FindObjectOfType<PlayerRotation>().gameObject.GetComponent<Animator>();
                return anim;
            }
        }
        private static float moveSpeed;
        public static float MoveSpeed
        {
            get { return moveSpeed; }
            set
            {
                moveSpeed = value;
                moveSpeed = Mathf.Clamp(moveSpeed, 3, 100);
            }
        }
        private static float hp;
        public static float Hp
        {
            get { return hp; }
            set
            {
                hp = value;
            }
        }
        private static float stamina;
        public static float Stamina
        {
            get { return stamina; }
            set
            {
                stamina = value;
            }
        }
        private static Animator anim;
        #region �÷��̾� ������
        public class PlayerData
        {
            public static void InitPlayerStatSetting(PlayerDataSO data)
            {
                MoveSpeed = data.moveSpeed;
                Hp = data.hp;
                Stamina = data.stamina;
            }
        }

        /*
                private static Weaponable currentWeapon;
                public static Weaponable CurrentWeapon => currentWeapon; //���� ���� ������ �ִ� ������ Ÿ��

                public class WeaponManager //
                {
                    private Dictionary<string, Weapon<WeaponDataSO>> weapons = new();


                    private Transform trmParent;
                    public WeaponManager(Transform trmParent)
                    {
                        this.trmParent = trmParent;
                    }
                    public void CreateWeapon(Weaponable prefab, WeaponDataSO weaponData)
                    {
                        Weapon<Weaponable> weapon = new Weapon<Weaponable>(prefab, weaponData);
                        weapons.Add(prefab.gameObject.name, weaponData);
                    }
                }

                public class Weapon<T> where T : Weaponable
                {
                    public Weapon(T prefab, WeaponDataSO weapon)
                    {

                    }
                    public void InitWeaponSetting(T InitWeapon)
                    {
                        currentWeapon = InitWeapon;
                        weaponDatas.Add(InitWeapon);
                    }
                    public static void ChangedWeapon(T nextWeapon)
                    {
                        currentWeapon = nextWeapon;
                    }
                    public static void CreateWeapon(T weapon)
                    {
                        weaponDatas.Add(weapon);
                    }
                }*/
        #endregion
    }
}
