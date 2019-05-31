using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//岩崎
public class CameraController : MonoBehaviour
{
    [SerializeField] Camera target;
    void Start()
    {
        //カメラのトラッキングOFF
        XRDevice.DisableAutoXRCameraTracking(target, true);
        //Camera camera;
        target.stereoTargetEye = StereoTargetEyeMask.Both;
        //target.stereoTargetEye = StereoTargetEyeMask.None;
    }
}
