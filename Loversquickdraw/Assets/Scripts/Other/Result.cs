
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
    [SerializeField] private Text text;

    //勝敗に関係するフラグ
    public static bool gameSet;
    public static bool Player1Win;
    public static bool Player2Win;
    
    //プレイヤー
    [SerializeField] private Rigidbody player1;
    [SerializeField] private Rigidbody player2;

    //ゴールにいるキャラのアニメーション
    [SerializeField] private Animator _animator;

    //
    void Start()
    {
        gameSet = false;
        Time.timeScale = 1.0f;
        text.enabled = false;
        for (int i = 0; i <= images.Length - 1; i++)
        {
            images[i].enabled = false;
        }
        //アニメーションが時間の影響受けずに再生されるようにする
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    //
    void Update()
    {

        GameSet();

    }
    //ゲーム終了時に次のシナリオへ
    private void GameSet()
    {
        
        if (gameSet == true)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                SceneLoadManager.LoadScene("Scenario");
            }
        }
    }
    
    void Player1WinCheck()
    {
        //Debug.Log("1Pの勝利");
        Player1Win = true;
        PlayerPrefs.SetInt("MiniGame2Data", 0);
        //Singlton.Instance.WinFlag[0] = 1;
        gameSet = true;
    }

    void Player2WinCheck()
    {
        //Debug.Log("2Pの勝利");
        Player2Win = true;
        PlayerPrefs.SetInt("MiniGame2Data", 1);
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
            text.enabled = true;
            images[0].enabled = true;
            images[2].enabled = true;
            Time.timeScale = 0f;
            
            Player1WinCheck();
        }
        else if (col.gameObject.tag == "Player2")
        {
            _animator.SetBool("Goal", true);
            text.enabled = true;
            images[1].enabled = true;
            images[3].enabled = true;
            Time.timeScale = 0f;
            
            Player2WinCheck();
        }
    }
}
