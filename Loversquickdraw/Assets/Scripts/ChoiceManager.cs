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
    private GameObject choice1;

    [SerializeField]
    private GameObject choice2;

    [SerializeField]
    private GameObject choice3;


    //[SerializeField]
    //private GameObject choice1Text;

    //[SerializeField]
    //GameObject choice2Text;

    //[SerializeField]
    //GameObject choice3Text;


    bool stopChoice = false;

    //基準は2.5秒
    [SerializeField]
    private float invokeTime;


    //trueの場合は1Pの勝ち、falseの場合は2Pの勝ち
    [HideInInspector]
    public bool firstsPlayer = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// ボタンを押し選択肢を選んだら
        /// それ以降ボタンを消し入力を断つ
        /// </summary>

        //1Pが1を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("1を押した");
            ChangeColor1();
            Invoke("Choise1", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Debug.Log("1Pが1を押した");
        }

        //2Pが1を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("1を押した");
            ChangeColor1();
            Invoke("Choise1", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Debug.Log("2Pが1を押した");
        }


        //1Pが2を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("2を押した");
            ChangeColor2();
            Invoke("Choise2", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Debug.Log("1Pが2を押した");
        }

        //2Pが2を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("2を押した");
            ChangeColor2();
            Invoke("Choise2", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Debug.Log("2Pが2を押した");

        }


        //1Pが3を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("3を押した");
            ChangeColor3();
            Invoke("Choise3", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Debug.Log("1Pが3を押した");
        }

        //2Pが3を押した判定
        if (stopChoice == false && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("3を押した");
            ChangeColor3();
            Invoke("Choise3", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Debug.Log("2Pが3を押した");

        }


    }
    //カラーコードは〇〇/255, で表示
    private void ChangeColor1()
    {
        Debug.Log("2と3を暗くする");
        choice2.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        choice3.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor2()
    {
        Debug.Log("1と3を暗くする");
        choice1.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        choice3.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor3()
    {
        Debug.Log("1と2を暗くする");
        choice1.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        choice2.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }



    private void Choise1()
    {
        Destroy(choice2);
        Destroy(choice3);
        Debug.Log("Choise1を通った");
    }

    private void Choise2()
    {
        Destroy(choice1);
        Destroy(choice3);
        Debug.Log("Choise2を通った");
    }

    private void Choise3()
    {
        Destroy(choice1);
        Destroy(choice2);
        Debug.Log("Choise3を通った");
    }

}
