using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Core
{
    public static class Core
    {
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
        #region 플레이어 데이터
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
        public static Weaponable CurrentWeapon => currentWeapon; //현재 내가 가지고 있는 무기의 타입

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
