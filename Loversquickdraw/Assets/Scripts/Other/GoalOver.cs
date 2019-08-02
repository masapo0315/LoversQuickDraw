using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalOver : MonoBehaviour {

    //ゴールを飛び越えてしまった時の処理

    private int player1LoveMetar;
    private int player2LoveMetar;

    // Use this for initialization
    void Start () {

        player1LoveMetar = LoveMetar.getPlayer1LoveMetar();
        player2LoveMetar = LoveMetar.getPlayer2LoveMetar();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            player1LoveMetar -= 5;
        }

        if (other.gameObject.tag == "Player2")
        {
            player2LoveMetar -= 5;
        }
    }
}
