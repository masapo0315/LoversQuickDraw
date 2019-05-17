using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour {

    int comment = 0;
    int name = 0;

    string[][] Talk = new string[][]
    {
        new string[]{"おはよう","Player1"},
        new string[]{"こんにちは","Player2"},
        new string[]{"こんばんは","Player1"},
    };
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            name++;
            if (name >= 3)
            {
                name = 0;
            }

            //name %= 3;

            Debug.Log("Talk[" + name + "][" + comment + "]=" + Talk[name][comment]);
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    comment++;
        //    comment %= 2;
        //    Debug.Log("Talk[" + name + "][" + comment + "]=" + Talk[name][comment]);
        //}
    }

}
