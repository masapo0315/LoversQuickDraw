using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class textFormatTest : MonoBehaviour {

    public Text text;
    private string[] name = new string[]
    {
        "user1","user2"
    };
    private string[] textstr = new string[]{

        "test:配列１: {1}。:test\ntesttest",
        "{0}test2"
    };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            text.text = string.Format(textstr[0],name);
        }
	}
}
