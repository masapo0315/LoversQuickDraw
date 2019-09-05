using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    //
    [SerializeField] private Image[] winnerImages;

    //　TalkManager作成後にResultSceneで会話が終わったときにこのboolをtrueにする
    [HideInInspector] public bool _talkCheck = false;

    private void Start()
    {
        for(int i = 0; i < winnerImages.Length; i++)
        {
            winnerImages[i].enabled = false;
        }
    }
    private void Update()
    {
        if(_talkCheck == true)
        {
            if (LoveMetar.player1LoveMetar > LoveMetar.player2LoveMetar)
            {
                winnerImages[0].enabled = true;
                Debug.Log("1PWin");
            }
            else if (LoveMetar.player2LoveMetar > LoveMetar.player1LoveMetar)
            {
                winnerImages[1].enabled = true;
                Debug.Log("2PWin");
            }
            else if (LoveMetar.player1LoveMetar == LoveMetar.player2LoveMetar)
            {
                Debug.Log("引き分け");
            }
        }
    }
}
