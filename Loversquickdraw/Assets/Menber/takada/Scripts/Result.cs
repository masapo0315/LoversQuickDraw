using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Image[] images = new Image[3];
   

	// Use this for initialization
	void Start () {

        for (int i = 0; i <= 2; i++)
        {
            images[i].enabled = false;
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("オブジェクトが触れました");

        if (col.gameObject.tag == "Player1")
        {
            images[0].enabled = true;
            images[2].enabled = true;
            Time.timeScale = 0f;
            Debug.Log("1Pの勝利");
        }
        else if (col.gameObject.tag == "Player2")
        {
            images[1].enabled = true;
            images[2].enabled = true;
            Time.timeScale = 0f;
            Debug.Log("2Pの勝利");
        }

    }
}
