using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

    //ゴールした時のリザルトを表示する

    public Image[] images;

    bool gameSet = false;

    int player1LoveMetar;
    int player2LoveMetar;


    // Use this for initialization
    void Start () {

        player1LoveMetar = LoveMetar.getPlayer1LoveMetar();
        player2LoveMetar = LoveMetar.getPlayer2LoveMetar();

        for (int i = 0; i <= images.Length - 1; i++)
        {
            images[i].enabled = false;
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
        GameSet();
    }

    void GameSet()
    {
        if(gameSet == true)
        {
            SceneManager.LoadScene("");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("オブジェクトが触れました");

        if (col.gameObject.tag == "Player1")
        {
            images[0].enabled = true;
            images[2].enabled = true;
            player1LoveMetar += 10;
            Time.timeScale = 0f;
            Debug.Log("1Pの勝利");
            gameSet = true;
        }
        else if (col.gameObject.tag == "Player2")
        {
            images[1].enabled = true;
            images[3].enabled = true;
            player2LoveMetar += 10;
            Time.timeScale = 0f;
            Debug.Log("2Pの勝利");
            gameSet = true;
        }

    }
}
