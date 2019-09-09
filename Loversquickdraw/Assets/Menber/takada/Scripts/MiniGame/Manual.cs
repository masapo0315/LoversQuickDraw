using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manual : MonoBehaviour {

    /// <summary>
    /// ミニゲーム1の説明からゲームにscene移動する
    /// </summary>

    //それぞれのプレイヤーが決定ボタンを押したか
    private bool Player1Enter;
    private bool Player2Enter;


	// Use this for initialization
	void Start () {

        Player1Enter = false;
        Player2Enter = false;

	}
	
	// Update is called once per frame
	void Update () {

        FlackChange();
        FlagCheck();

	}
    
    //フラグのチェック
    private void FlagCheck()
    {
        if (Player1Enter == true && Player2Enter == true)
        {
            SceneManager.LoadScene("MiniGame1");
        }
    }

    //ボタン入力でフラグの切り替え(falseにも切り替え可)
    private void FlackChange()
    {
        if (Player1Enter == false && Input.GetKeyDown(KeyCode.A))
        {
            Player1Enter = true;
            Debug.Log(Player1Enter);
        }

        if (Player2Enter == false && Input.GetKeyDown(KeyCode.B))
        {
            Player2Enter = true;
            Debug.Log(Player2Enter);
        }
        
    }

}
