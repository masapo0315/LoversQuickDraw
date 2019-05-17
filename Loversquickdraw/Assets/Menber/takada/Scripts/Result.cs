using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("オブジェクトが触れました");

        if (col.gameObject.tag == "Player1")
        {
            Time.timeScale = 0f;
            Debug.Log("1Pの勝利");
        }
        else if (col.gameObject.tag == "Player2")
        {
            Time.timeScale = 0f;
            Debug.Log("2Pの勝利");
        }

    }
}
