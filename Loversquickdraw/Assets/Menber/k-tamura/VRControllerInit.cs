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
    /// <summary>
    /// VRControllerのX軸の現在の値を取る。
    /// </summary>
    /// <returns>string(LTouch,RTouch)</returns>
    public static string VRControllerInitialize()
    {
        Instance._LTouchX = OVRInput.GetLocalControllerPosition(Instance.LTouch).x;
        Instance._RTouchX = OVRInput.GetLocalControllerPosition(Instance.RTouch).x;
        return (Instance._LTouchX.ToString()+","+Instance._RTouchX.ToString());
    } 
}
