using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// いじらないで
/// </summary>右コントローラーのスティック押し込み

//岩崎
public static class InputManager
{
    //ボタン入力
    public static OVRInput.Button GetButton(int buttonNum)
    {
        switch (buttonNum)
        {
            case 1:
                return OVRInput.Button.One;                 //Aボタン
            case 2:
                return OVRInput.Button.Two;                 //Bボタン
            case 3:
                return OVRInput.Button.Three;               //Xボタン
            case 4:
                return OVRInput.Button.Four;                //Yボタン
            case 5:
                return OVRInput.Button.Start;               //Startボタン(左コントローラーのスティックの下のボタン)
            case 6:
                return OVRInput.Button.SecondaryThumbstickDown; //右コントローラーのスティック押し込み
            case 7:
                return OVRInput.Button.SecondaryThumbstickLeft;   //左コントローラーのスティック押し込み
            default:
                return OVRInput.Button.None;                //defaultの値
        }
    }
    //タッチ部分
    public static OVRInput.Touch GetTouch(int touthNum)
    {
        switch (touthNum)
        {
            case 1:
                return OVRInput.Touch.SecondaryThumbRest;   //右コントローラー
            case 2:
                return OVRInput.Touch.PrimaryThumbRest;     //左コントローラー
            default:
                return OVRInput.Touch.None;
        }
    }
    //トリガー入力
    public static OVRInput.Axis1D GetAxis1(int axis1Num)
    {
        switch (axis1Num)
        {
            case 1:
                return OVRInput.Axis1D.SecondaryHandTrigger;    //右手中指のボタン
            case 2:
                return OVRInput.Axis1D.SecondaryIndexTrigger;   //右手人差し指のボタン
            case 3:
                return OVRInput.Axis1D.PrimaryHandTrigger;      //左手中指のボタン
            case 4:
                return OVRInput.Axis1D.PrimaryIndexTrigger;     //左手人差し指のボタン
            default:
                return OVRInput.Axis1D.None;
        }
    }
    //スティックの取得
    public static OVRInput.Axis2D GetAxis2(int axis2Num)
    {
        switch (axis2Num)
        {
            case 1:
                return OVRInput.Axis2D.SecondaryThumbstick;     //右コントローラーのスティック
            case 2:
                return OVRInput.Axis2D.PrimaryThumbstick;       //左コントローラーのスティック
            default:
                return OVRInput.Axis2D.None;
        }
    }
}
