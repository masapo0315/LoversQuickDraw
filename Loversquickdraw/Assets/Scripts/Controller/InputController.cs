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

    Vector3 L_defPos;
    Vector3 R_defPos;
    


    private void Start()
    {
        L_defPos = Lcube.transform.position;
        R_defPos = Rcube.transform.position;
    }
    void Update ()
    {
        Debug.Log(L_defPos.y);
        Debug.Log(R_defPos.y);
        if (Lcube.transform.position.y >= L_defPos.y + 0.3f && Lcube.transform.position.y <= L_defPos.y - 0.3f)
        {
            Debug.Log("L_Conふってる");
        }
        else if (Lcube.transform.position.y < L_defPos.y + 0.3f && Lcube.transform.position.y > L_defPos.y - 0.3f)
        {
            Debug.Log("L_Conふってる");
        }
        L_text.text = Lcube.transform.position.y.ToString();
        R_text.text = Rcube.transform.position.y.ToString();
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
