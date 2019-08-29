using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class InputName : MonoBehaviour {

    //名前入力に関係するScript
    

    [SerializeField]
    private Text inputname = null;

    [SerializeField]
    private Text nomalText;

    [SerializeField]
    private Text errorText;

    //文字数
    private int nameCount;

    public static string Player1Name;

    [SerializeField]
    private GameObject input;

    [SerializeField]
    private GameObject Confirmation;

    private void Start()
    {

    }

    //テキストの中に文字を追加
    public void OnAddString(string inputString)
    {

        //１０文字以上入力できないようにする
        if (nameCount < 10){

             inputname.text += inputString;
             nameCount += 1;
            Debug.Log(nameCount);
             nomalText.gameObject.SetActive(true);
             errorText.gameObject.SetActive(false);

        }
        
    }

    //テキストの中の文字を削除
    public void DestroyString()
    {
        //文字が入っていなければ何もしない
        if (nameCount == 0) { return; }  

        string text = inputname.text.Substring(0, inputname.text.Length - 1);
        inputname.text = text;
        nameCount -= 1;
        
    }

    
    //名前の決定
    public void EnterName()
    {
        //名前が入力されていなかったら決定できないようにする
        if (nameCount != 0)
        {
             Player1Name = inputname.text;

             input.SetActive(false);
             Confirmation.SetActive(true);

        } else {

             nomalText.gameObject.SetActive(false);
             errorText.gameObject.SetActive(true);

         }
        
    }
    

}
