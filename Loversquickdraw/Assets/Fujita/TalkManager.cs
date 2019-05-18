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
        new string[]{"こんばんは","Player3"},
    };
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("Talk[" + name + "][" + comment + "]=" + Talk[name][comment]);
            name++;
            if (name >= 3)
            {
                name = 0;
            }
            //name %= 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Talk[" + name + "][" + comment + "]=" + Talk[name][comment]);
            comment++;
            comment %= 2;
        }
    }

}
