using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour {

    //入力用の文字ボタンが押されたことを検知する

    [SerializeField]
    private string str;

    [SerializeField]
    private GameObject gameobject;

    //アイコンが触れている間にボタンを押したら文字を入力する

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Icon")
        {
            
        }
        if(Input.GetButton("submit"))
        {
            gameObject.GetComponent<InputName>().OnAddString(str);
        }
    }
}
