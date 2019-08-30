using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DestryNameVR : MonoBehaviour {

    //入力した文字を削除

    public InputNameVR inputNameVR;

    [SerializeField]
    private Text inputName;

    int namecount;

	// Use this for initialization
	void Start () {

        inputName = inputNameVR.inputname;
	}

    private void Update()
    {
        namecount = inputNameVR.nameCount;
    }

    private void OnTriggerEnter(Collider col)
    {
        DestroyString(col);
    }

    private void OnTriggerStay(Collider other)
    {
        DestroyString(other);
    }

    //テキストの中の文字を削除
    public void DestroyString(Collider _col)
    {
        if (_col.gameObject.tag == "Icon" && Input.GetButton("submit"))
        {
            Debug.Log(namecount);
            //文字が入っていなければ何もしない
            if (namecount <= 0) { return; }
            else
            {
                string text = inputName.text.Substring(0, inputName.text.Length - 1);
                inputName.text = text;
                Debug.LogWarning(namecount);
                namecount -= 1;

            }
        }
    }
}
