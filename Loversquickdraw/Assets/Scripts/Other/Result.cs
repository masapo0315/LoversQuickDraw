
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //ゴールした時のリザルトを表示する

    //表示するUIの配列
    public Image[] images;

    //勝敗に関係するフラグ
    public static bool gameSet = false;
    public static bool Player1Win;
    public static bool Player2Win;
    
    //プレイヤーの好感度
    private int player1LoveMetar;
    private int player2LoveMetar;

    //プレイヤー
    [SerializeField] private Rigidbody player1;
    [SerializeField] private Rigidbody player2;

    //プレイヤーの速度
    private float player1Speed;
    private float player2Speed;

    //ゴールにいるキャラのアニメーション
    [SerializeField] private Animator _animator;
    
    //
    void Start ()
    {
        Time.timeScale = 1.0f;

        player1LoveMetar = LoveMetar.getPlayer1LoveMetar();
        player2LoveMetar = LoveMetar.getPlayer2LoveMetar();

        for (int i = 0; i <= images.Length - 1; i++)
        {
            images[i].enabled = false;
        }

        //アニメーションが時間の影響受けずに再生されるようにする
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;    
    }



	//
	void Update ()
    {
        GameSet();
        SpeedCheck();
    }

    //ゲーム終了時に次のシナリオへ
    private void GameSet()
    {
        if(gameSet == true)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                SceneManager.LoadScene("Scenario2");
            }
        }   
    }
    
    //プレイヤーの速度を計測
    private void SpeedCheck()
    {
        player1Speed = player1.velocity.magnitude;
        Debug.Log(player1Speed);
        player2Speed = player2.velocity.magnitude;

    }

    void Player1WinCheck()
    {
        //Debug.Log("1Pの勝利");
        Player1Win = true;

        //Singlton.Instance.WinFlag[0] = 1;
        gameSet = true;
    }

    void Player2WinCheck()
    {
        //Debug.Log("2Pの勝利");
        Player2Win = true;

        //Singlton.Instance.WinFlag[0] = 2;
        gameSet = true;
    }

    //どちらか先に触れたほうの好感度を上げる
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("オブジェクトが触れました");

        if (col.gameObject.tag == "Player1")
        { 
            _animator.SetBool("Goal", true);

            images[0].enabled = true;
            images[2].enabled = true;
            Time.timeScale = 0f;

            //ただし速度が速すぎた場合好感度が下がる
            if(player1Speed > 9)
            {
                player1LoveMetar -= 10; 
            } else {
                player1LoveMetar += 10;
            }

            Player1WinCheck();

        }
        else if (col.gameObject.tag == "Player2")
        {
            _animator.SetBool("Goal", true);

            images[1].enabled = true;
            images[3].enabled = true;
            Time.timeScale = 0f;

            if (player1Speed > 9)
            {
                player2LoveMetar -= 10;
            } else {
                player2LoveMetar += 10;
            }

            Player2WinCheck();
        }
    }
}
