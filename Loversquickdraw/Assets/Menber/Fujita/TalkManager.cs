using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour {


    //縦
    int Talktext = 0;
    //横
    new int name = 0;
    public GameObject NameTextmanager;
    public GameObject CommentTextmanager;

    //コメントと話すキャラの名前の配列
    string[][] Talk = new string[][]
    {
        //画面表示文字は今は仮で２行まで(全32文字)
        new string[]{"１８文字目で改行させるあいうえおかき\n↑で１８字", "夢宮 華恋"},
        new string[]{"こんにちは","Player1"},
        new string[]{"こんばんは","Player2"},
    };
    
    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Text Nametext = NameTextmanager.GetComponent<Text>();
            Text Commenttext = CommentTextmanager.GetComponent<Text>();
            name = 1;
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
            Nametext.text = Talk[Talktext][name];
            name = 0;
            Commenttext.text = Talk[Talktext][name];
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
            Talktext++;

            //とりあえず配列３つを仮で作ったから３回ループでリセット
            if (Talktext == 3)
            {
                Talktext = 0;
            }
        }
    }

}
