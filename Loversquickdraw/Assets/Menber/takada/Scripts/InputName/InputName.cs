using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    //名前入力

    [SerializeField]
    private Text inputname = null;

    public static string Player1Name;

    //テキストの中に文字を追加
    public void OnAddString(string inputString)
    {
        inputname.text += inputString;
    } 

    //テキストの中の文字を削除
    public void DestroyString(string deleteString)
    {
        
    }

    //名前の決定
    public void EnterName()
    {
        inputname.text = Player1Name;
    }

}
