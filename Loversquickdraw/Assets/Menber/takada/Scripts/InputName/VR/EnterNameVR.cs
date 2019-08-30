using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class EnterNameVR : MonoBehaviour {

    private InputNameVR inputNameVR;

    [SerializeField]
    private Text inputname;

    int namecount;

    // Use this for initialization
    void Start () {

        inputname = inputNameVR.inputname;
        namecount = inputNameVR.nameCount;

    }



    //名前の決定
    public void EnterName()
    {
        //名前が入力されていなかったら決定できないようにする
        if (namecount != 0)
        {
            Player1name = inputname.text;

            input.SetActive(false);
            Confirmation.SetActive(true);

        }
        else
        {

            nomalText.gameObject.SetActive(false);
            errorText.gameObject.SetActive(true);

        }

    }

}
