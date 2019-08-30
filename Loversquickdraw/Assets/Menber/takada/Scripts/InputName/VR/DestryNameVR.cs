using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DestryNameVR : MonoBehaviour {

    private InputNameVR inputNameVR;

    [SerializeField]
    private Text inputname;

    int namecount;

	// Use this for initialization
	void Start () {

        inputname = inputNameVR.inputname;
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
            //文字が入っていなければ何もしない
            if (namecount == 0) { return; }

            string text = inputname.text.Substring(0, inputname.text.Length - 1);
            inputname.text = text;
            namecount -= 1;

        }
    }
}
