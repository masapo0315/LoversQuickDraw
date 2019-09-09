using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerInit : SingletonMonoBehaviour<VRControllerInit> {
    [Header("Controller")]
    [SerializeField] OVRInput.Controller LTouch;

    [SerializeField] OVRInput.Controller RTouch;
    [Header("Log")]
    [SerializeField] float _LTouchX;
    [SerializeField] float _RTouchX;
    [SerializeField] float[] _Touch;
    /// <summary>
    /// VRControllerのX軸の現在の値を取る。
    /// </summary>
    /// <returns>string(LTouch,RTouch)</returns>
    public static float[] NowVRControllerPos()
    {
        Instance._LTouchX = OVRInput.GetLocalControllerPosition(Instance.LTouch).x;
        Instance._RTouchX = OVRInput.GetLocalControllerPosition(Instance.RTouch).x;
        Instance._Touch[0] = Instance._LTouchX;
        Instance._Touch[1] = Instance._RTouchX;
        return Instance._Touch;
    } 
    
}
