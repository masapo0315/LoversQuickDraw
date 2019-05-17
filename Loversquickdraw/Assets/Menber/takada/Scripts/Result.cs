using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    bool ResultFlag;
    public Text text1; // 1P WIN
    public Text text2; // 2P WIN

	// Use this for initialization
	void Start () {
        text1 = GetComponent<Text>();
        text2 = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionStay(Collision col)
    {
        //どちらが先にゴールしたかの判定
        if(ResultFlag == true)
        {
            if (col.gameObject.tag == "Player1")
            {
                text1.enabled = true;
            }
            else if (col.gameObject.tag == "Player2")
            {
                text2.enabled = true;
            }
        }

    }
}
