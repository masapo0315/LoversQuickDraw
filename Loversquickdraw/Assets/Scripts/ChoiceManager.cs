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
    GameObject Choice1;
    [SerializeField]
    GameObject Choice1Text;

    [SerializeField]
    GameObject Choice2;
    [SerializeField]
    GameObject Choice2Text;

    [SerializeField]
    GameObject Choice3;
    [SerializeField]
    GameObject Choice3Text;

    bool StopChoice = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押し選択肢を選んだら、それ以降ボタンを消し入力を断つ
        if (Input.GetKeyDown(KeyCode.Keypad1) && StopChoice == false)
        {
            Debug.Log("1を押した");
            ChangeColor1();
            Invoke("Choise1", 3.5f);
            StopChoice = true;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && StopChoice == false)
        {
            Debug.Log("2を押した");
            ChangeColor2();
            Invoke("Choise2", 3.5f);
            StopChoice = true;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && StopChoice == false)
        {
            Debug.Log("3を押した");
            ChangeColor3();
            Invoke("Choise3", 3.5f);
            StopChoice = true;
        }

    }
    //カラーコードは〇〇/255, で表示
    private void ChangeColor1()
    {
        Debug.Log("2と3を暗くする");
        Choice2.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        Choice3.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor2()
    {
        Debug.Log("1と3を暗くする");
        Choice1.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        Choice3.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }

    private void ChangeColor3()
    {
        Debug.Log("1と2を暗くする");
        Choice1.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
        Choice2.GetComponent<Image>().color = new Color(120 / 255f, 120 / 255f, 120 / 255f);
    }



    private void Choise1()
    {
        Choice2.SetActive(false);
        Choice3.SetActive(false);
        Debug.Log("Choise1を通った");      
    }

    private void Choise2()
    {
        Choice1.SetActive(false);
        Choice3.SetActive(false);
        Debug.Log("Choise2を通った");
    }

    private void Choise3()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        Debug.Log("Choise3を通った");
    }

}
