using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    //名前入力に関係するScript

    [SerializeField]
    private Text inputname = null;

    private int nameCount;

    public static string Player1Name;

    //テキストの中に文字を追加
    public void OnAddString(string inputString)
    {
        if(nameCount < 10)
        {
            inputname.text += inputString;
            nameCount += 1;

        }
    } 

    //テキストの中の文字を削除
    public void DestroyString()
    {

    }

    //名前の決定
    public void EnterName()
    {
        inputname.text = Player1Name;
    }

}
