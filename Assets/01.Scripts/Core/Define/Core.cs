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
        public static Vector3 MousePos
        {
            get
            {
                return Cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }

    }
}
