using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class EnterNameVR : MonoBehaviour {

    //入力した文字を決定

    public InputNameVR inputNameVR;

    [SerializeField]
    private Text inputName;

    string player1name;
    int namecount;

    [SerializeField]
    private GameObject input;

    [SerializeField]
    private GameObject confirmation;

    [SerializeField]
    private Text nomalText;

    [SerializeField]
    private Text errorText;

    // Use this for initialization
    void Start () {

        inputName = inputNameVR.inputname;
        player1name = InputNameVR.Player1name;
    }

    private void Update()
    {
        namecount = inputNameVR.nameCount;
    }

    private void OnTriggerEnter(Collider col)
    {
        EnterName(col);
    }

    private void OnTriggerStay(Collider other)
    {
        EnterName(other);        
    }

    //名前の決定
    public void EnterName(Collider _col)
    {
        if(_col.gameObject.tag == "Icon" && Input.GetButton("submit"))
        {
            //名前が入力されていなかったら決定できないようにする
            if (namecount != 0)
            {
                player1name = inputName.text;

                input.SetActive(false);
                confirmation.SetActive(true);

            }
            else
            {

                nomalText.gameObject.SetActive(false);
                errorText.gameObject.SetActive(true);

            }

        }

    }

}
