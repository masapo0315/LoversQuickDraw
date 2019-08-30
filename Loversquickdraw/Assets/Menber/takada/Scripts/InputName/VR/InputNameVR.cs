using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class InputNameVR : MonoBehaviour
{

    //名前入力に関係するScript


    public Text inputname;

    [SerializeField]
    private string inputString;

    [SerializeField]
    private Text nomalText;

    [SerializeField]
    private Text errorText;

    //文字数
    public int nameCount;

    public static string Player1name;

    [SerializeField]
    private GameObject input;

    [SerializeField]
    private GameObject Confirmation;

    private void OnTriggerEnter(Collider col)
    {
        OnAddString(col);
    }

    private void OnTriggerStay(Collider other)
    {
        OnAddString(other);
    }

    //テキストの中に文字を追加
    public void OnAddString(Collider _col)
    {
        if(_col.gameObject.tag == "Icon" && Input.GetButton("submit"))
        {
            //１０文字以上入力できないようにする
            if (nameCount < 10)
            {

                inputname.text += inputString;
                nameCount += 1;
                Debug.Log(nameCount);
                nomalText.gameObject.SetActive(true);
                errorText.gameObject.SetActive(false);

            }

        }

    }

}
