using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    private void Update()
    {
        if(LoveMetar.player1LoveMetar > LoveMetar.player2LoveMetar)
        {
            Debug.Log("1PWin");
        }
        else if(LoveMetar.player2LoveMetar > LoveMetar.player1LoveMetar)
        {
            Debug.Log("2PWin");
        }
        else if(LoveMetar.player1LoveMetar == LoveMetar.player2LoveMetar)
        {
            Debug.Log("引き分け");
        }
    }
}
