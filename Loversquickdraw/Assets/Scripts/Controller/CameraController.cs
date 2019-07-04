using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//岩崎
public class CameraController : MonoBehaviour
{
    [SerializeField]private Camera target;
    void Start()
    {
        //カメラのトラッキングOFF
        XRDevice.DisableAutoXRCameraTracking(target, true);
        //スクリプトからカメラを固定
        target.stereoTargetEye = StereoTargetEyeMask.Both;
        XRSettings.showDeviceView = false;
    }
}
