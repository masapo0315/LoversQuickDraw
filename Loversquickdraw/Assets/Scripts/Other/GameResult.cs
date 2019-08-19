using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private Image[] winnerImages;

    private int _player1LoveMetar;

    private void Start()
    {
        for(int i = 0; i < winnerImages.Length; i++)
        {
            winnerImages[i].enabled = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _player1LoveMetar += 10;
            Debug.Log("Space");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _player1LoveMetar -= 10;
            Debug.Log("Escape");
        }
        if (LoveMetar.player1LoveMetar > LoveMetar.player2LoveMetar)
        {
            winnerImages[0].enabled = true;
            Debug.Log("1PWin");
        }
        else if(LoveMetar.player2LoveMetar > LoveMetar.player1LoveMetar)
        {
            winnerImages[1].enabled = true;
            Debug.Log("2PWin");
        }
        else if(LoveMetar.player1LoveMetar == LoveMetar.player2LoveMetar)
        {
            Debug.Log("引き分け");
        }
    }
}
