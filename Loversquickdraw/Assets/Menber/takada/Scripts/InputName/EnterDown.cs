using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDown : MonoBehaviour {

    [SerializeField]
    private GameObject gameobject;

    //アイコンが触れている間にボタンを押したら文字を決定

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Icon")
        {

        }
        if (Input.GetButton("submit"))
        {
            gameObject.GetComponent<InputName>().EnterName();
        }
    }
}
