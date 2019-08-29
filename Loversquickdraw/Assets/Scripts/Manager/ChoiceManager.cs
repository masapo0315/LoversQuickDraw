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

    [SerializeField] private GameObject choiceAorX;
    [SerializeField] private GameObject choiceBorY;
    [SerializeField] private GameObject choiceTrigger;
    [SerializeField] private GameObject FrameText;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject cursor2;
    [HideInInspector] public int rootflag;

    private bool destroyFlag = false;

    //基準は2.5秒
    [SerializeField] private float invokeTime = 2.5f;
    [SerializeField] private TalkManager talkManager;
    [SerializeField] private ChoiceCursor choiceCursor;

    [HideInInspector] public bool stopChoice = false;
    //trueの場合は1Pの勝ち、falseの場合は2Pの勝ち
    [HideInInspector] public bool firstsPlayer = false;

    private void Start()
    {
        cursor.SetActive(false);
        cursor2.SetActive(false);
    }
    public void PushButton()
    {
        /// <summary>
        /// ボタンを押し選択肢を選んだら
        /// それ以降ボタンを消し入力を断つ
        /// </summary>

        //1Pが1を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 0 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが1を押した");
            cursor2.SetActive(false);
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyAorX", invokeTime * 2);
            rootflag = 1;
            //talkManager.ChoiceRoot();
            Debug.Log("choice1-1");
        }

        //2Pが1を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 0 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが1を押した");
            cursor.SetActive(false);
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyAorX", invokeTime * 2);
            rootflag = 1;
            Debug.Log("choice2-1");
        }

        //1Pが2を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 1 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが2を押した");
            cursor2.SetActive(false);
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyBorY", invokeTime * 2);
            rootflag = 2;
            Debug.Log("choice1-2");
        }

        //2Pが2を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 1 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが2を押した");
            cursor.SetActive(false);
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyBorY", invokeTime * 2);
            rootflag = 2;
            Debug.Log("choice2-2");
        }

        //1Pが3を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 2 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが3を押した");
            cursor2.SetActive(false);
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyTrigger", invokeTime * 2);
            rootflag = 3;
            Debug.Log("choice1-3");
        }

        //2Pが3を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 2 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが3を押した");
            cursor.SetActive(false);
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyTrigger", invokeTime * 2);
            rootflag = 3;
            Debug.Log("choice2-3");
        }
    }
    public void DebugPushButton()
    {
        /// <summary>
        /// ボタンを押し選択肢を選んだら
        /// それ以降ボタンを消し入力を断つ
        /// </summary>

        //1Pが1を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("1Pが1を押した");
            cursor2.SetActive(false);
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyAorX", invokeTime * 2);
            rootflag = 1;
            Debug.Log("choice1-1");
        }

        //2Pが1を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが1を押した");
            cursor.SetActive(false);
            ChangeColor1();
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyAorX", invokeTime * 2);
            rootflag = 1;
            Debug.Log("choice2-1");
        }

        //1Pが2を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("1Pが2を押した");
            cursor2.SetActive(false);
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyBorY", invokeTime * 2);
            rootflag = 2;
            Debug.Log("choice1-2");
        }

        //2Pが2を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが2を押した");
            cursor.SetActive(false);
            ChangeColor2();
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyBorY", invokeTime * 2);
            rootflag = 2;
            Debug.Log("choice2-2");
        }

        //1Pが3を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("1Pが3を押した");
            cursor2.SetActive(false);
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            Invoke("DestroyTrigger", invokeTime * 2);
            rootflag = 3;
            Debug.Log("choice1-3");
        }

        //2Pが3を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが3を押した");
            cursor.SetActive(false);
            ChangeColor3();
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            Invoke("DestroyTrigger", invokeTime * 2);
            rootflag = 3;
            Debug.Log("choice2-3");
        }
        //Invoke("talkManager.Forced",2);
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
    //
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
    //
    public bool getStopchoice()
    {
        return stopChoice;
    }
    public bool getdestroyFlag()
    {
        return destroyFlag;
    }
    //
    private void DestroyAorX()
    {
        Destroy(choiceAorX);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
    }
    private void DestroyBorY()
    {
        Destroy(choiceBorY);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
    }
    private void DestroyTrigger()
    {
        Destroy(choiceTrigger);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
    }
    //
    public void SetActive()
    {
        choiceAorX.SetActive(true);
        choiceBorY.SetActive(true);
        choiceTrigger.SetActive(true);
    }
}
