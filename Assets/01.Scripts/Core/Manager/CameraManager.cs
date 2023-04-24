using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
    private float cameraDistance;
    [SerializeField]
    private float sensitivity = 70;

    [SerializeField]
    private float minZoomSize = 5;
    [SerializeField]
    private float maxZoomSize = 15;

    private void Update()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent<CinemachineComponentBase>();
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            if (componentBase is CinemachineFramingTransposer)
            {
                var a = (componentBase as CinemachineFramingTransposer);
                a.m_CameraDistance -= cameraDistance;

                a.m_CameraDistance = Mathf.Clamp(a.m_CameraDistance, minZoomSize, maxZoomSize);
                //_ = Mathf.Clamp(a.m_CameraDistance, 50, 70);

            }
        }
    }

}
