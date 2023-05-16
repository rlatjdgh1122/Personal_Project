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

        public static GameObject currentWeapon;

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
            public static void InitPlayerStatSetting(PlayerInitStatData data)
            {
                MoveSpeed = data.moveSpeed;
                Hp = data.hp;
                Stamina = data.stamina;
            }
        }
        #endregion
    }
}
