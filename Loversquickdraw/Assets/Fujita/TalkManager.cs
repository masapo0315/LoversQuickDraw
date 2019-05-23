﻿using System.Collections;
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

    string[][] Talk = new string[][]
    {
        new string[]{"おはようああああああああああああああ\n改行", "夢宮 華恋"},
        new string[]{"こんにちは","Player1"},
        new string[]{"こんばんは","Player2"},
    };
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Text Nametext = NameTextmanager.GetComponent<Text>();
            Text Commenttext = CommentTextmanager.GetComponent<Text>();
            name = 1;
            Nametext.text = Talk[Talktext][name];
            name = 0;
            Commenttext.text = Talk[Talktext][name];
        //name = 1;
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
        //name = 0;
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
            Talktext++;
            if (Talktext == 3)
            {
                Talktext = 0;
            }
            //name %= 3;
        }
    }

}
