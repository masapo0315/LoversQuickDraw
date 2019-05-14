using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class CameraController : MonoBehaviour
{
    [SerializeField] Camera target;
    void Start()
    {
        //カメラのトラッキングOFF
        XRDevice.DisableAutoXRCameraTracking(target, true);
    }
}
