using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//富岡
public class ChoiceManager : MonoBehaviour
{
    /// <summary>
    /// 選択肢を選んだあとその選択肢を光らせ
    /// 選ばなかった選択肢を暗くし
    /// 一定時間後に選択肢を消す
    /// </summary>


    [SerializeField]
    private GameObject choiceAorX;

    [SerializeField]
    private GameObject choiceBorY;

    [SerializeField]
    private GameObject choiceTrigger;


    //[SerializeField]
    //private GameObject choice1Text;

    //[SerializeField]
    //GameObject choice2Text;

    //[SerializeField]
    //GameObject choice3Text;


    private bool stopChoice = false;

    //基準は2.5秒
    [SerializeField]
    private float invokeTime = 2.5f;


    //trueの場合は1Pの勝ち、falseの場合は2Pの勝ち
    [HideInInspector]
    public bool firstsPlayer = false;

    void Update()
    {
        /// <summary>
        /// ボタンを押し選択肢を選んだら
        /// それ以降ボタンを消し入力を断つ
        /// </summary>

        //1Pが1を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("1Pが1を押した");
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
        }

        //2Pが1を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("2Pが1を押した");
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
        }


        //1Pが2を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("1Pが2を押した");
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
        }

        //2Pが2を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("2Pが2を押した");
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
        }


        //1Pが3を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("1Pが3を押した");
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
        }

        //2Pが3を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("2Pが3を押した");
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
        }
    }
    //カラーコードは〇〇/255, で表示
    private void ChangeColor1()
    {
        Debug.Log("2と3を暗くする");
        
        choiceBorY.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        
        choiceTrigger.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor2()
    {
        Debug.Log("1と3を暗くする");
        
        choiceAorX.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        
        choiceTrigger.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor3()
    {
        Debug.Log("1と2を暗くする");
        
        choiceAorX.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        
        choiceBorY.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    
    private void GetAorX()
    {
        Destroy(choiceBorY);
        Destroy(choiceTrigger);
        Debug.Log("Choise1を通った");
    }

    private void GetBorY()
    {
        Destroy(choiceAorX);
        Destroy(choiceTrigger);
        Debug.Log("Choise2を通った");
    }

    private void GetTrigger()
    {
        Destroy(choiceAorX);
        Destroy(choiceBorY);
        Debug.Log("Choise3を通った");
    }

}
