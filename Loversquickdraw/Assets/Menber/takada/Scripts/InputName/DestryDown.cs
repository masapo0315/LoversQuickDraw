using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryDown : MonoBehaviour {

    [SerializeField]
    private GameObject gameobject;

    //アイコンが触れている間にボタンを押したら文字を消す

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Icon")
        {

        }
        if (Input.GetButton("submit"))
        {
            gameObject.GetComponent<InputName>().DestroyString();
        }
    }
}
