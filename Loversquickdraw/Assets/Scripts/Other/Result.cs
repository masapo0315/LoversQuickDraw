
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //ゴールした時のリザルトを表示する

    [SerializeField]private Image[] images;
    [SerializeField]private Animator _animator;

    private bool gameSet = false;
    public static bool Player1Win;
    public static bool Player2Win;

    private int player1LoveMetar;
    private int player2LoveMetar;
    
    void Start ()
    {
        Time.timeScale = 1.0f;

        player1LoveMetar = LoveMetar.getPlayer1LoveMetar();
        player2LoveMetar = LoveMetar.getPlayer2LoveMetar();

        for (int i = 0; i <= images.Length - 1; i++)
        {
            images[i].enabled = false;
        }
    }
	
	void Update ()
    {
        GameSet();
    }

    void GameSet()
    {
        if(gameSet == true)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                SceneManager.LoadScene("Scenario2");
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("オブジェクトが触れました");

        if (col.gameObject.tag == "Player1")
        {
            _animator.SetBool("Goal", true);

            images[0].enabled = true;
            images[2].enabled = true;

            player1LoveMetar += 10;
            Time.timeScale = 0f;

            //Debug.Log("1Pの勝利");

            Player1Win = true;
            gameSet = true;
        }
        else if (col.gameObject.tag == "Player2")
        {
            _animator.SetBool("Goal", true);

            images[1].enabled = true;
            images[3].enabled = true;

            player2LoveMetar += 10;
            Time.timeScale = 0f;

            //Debug.Log("2Pの勝利");

            Player2Win = true;
            gameSet = true;
        }
    }
}
