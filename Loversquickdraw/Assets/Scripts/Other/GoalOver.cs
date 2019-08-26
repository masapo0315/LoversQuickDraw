using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalOver : MonoBehaviour
{
    //ゴールを飛び越えてしまった時の処理
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            LoveMetar.player1LoveMetar -= 5;
        }
        if (other.gameObject.tag == "Player2")
        {
            LoveMetar.player2LoveMetar -= 5;
        }
    }
}
