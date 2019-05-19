using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class InputController : MonoBehaviour
{
    [SerializeField] GameObject Lcube;
    [SerializeField] GameObject Rcube;
    [SerializeField] Text L_text;
    [SerializeField] Text R_text;
    int a = 0;
    Vector3 L_defPos;
    Vector3 R_defPos;
    
    void Update ()
    {

        L_defPos = Lcube.gameObject.transform.position;
        R_defPos = Rcube.gameObject.transform.position;
        L_text.text = L_defPos.ToString();
        R_text.text = R_defPos.ToString();
        //if (L_defPos.y < -0.7f || L_defPos.y > 0f)
        //{
        //    Debug.Log("aaa");
        //}
        //else 
        //{
        //    Debug.Log("ssssssssssssssssssssssss");
        //}

        //if (OVRInput.GetDown(OVRInput.Touch.One))
        //{
        //    Debug.Log("Aボタンを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawTouch.B))
        //{
        //    Debug.Log("Bボタンを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.X))
        //{
        //    Debug.Log("Xボタンを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.Y))
        //{
        //    Debug.Log("Yボタンを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.Start))
        //{
        //    Debug.Log("メニューボタン（左アナログスティックの下にある）を押した");
        //}

        //if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        //{
        //    Debug.Log("右人差し指トリガーを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        //{
        //    Debug.Log("右中指トリガーを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        //{
        //    Debug.Log("左人差し指トリガーを押した");
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        //{
        //    Debug.Log("左中指トリガーを押した");
        //}
    }
}
