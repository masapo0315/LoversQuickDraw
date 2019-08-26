﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputName : MonoBehaviour {

    //名前入力に関係するScript

    [SerializeField]
    private Text inputname = null;

    //文字数
    private int nameCount;

    public static string Player1Name;

    [SerializeField]
    private GameObject Input;

    [SerializeField]
    private GameObject Confirmation;

    //テキストの中に文字を追加
    public void OnAddString(string inputString)
    {
        //１０文字以上入力できないようにする
        if(nameCount < 10)
        {
            inputname.text += inputString;
            nameCount += 1;
        }
    }

    //テキストの中の文字を削除
    public void DestroyString()
    {
        //文字が入っていなければ何もしない
        if (nameCount == 0) return;

        string text = inputname.text.Substring(0,inputname.text.Length-1);
        inputname.text = text;
        nameCount -= 1;
    }

    //名前の決定
    public void EnterName()
    {
        inputname.text = Player1Name;

        Input.SetActive(false);
        Confirmation.SetActive(true);
    }

}
