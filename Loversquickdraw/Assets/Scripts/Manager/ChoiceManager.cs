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
    public GameObject cursor;
    public GameObject cursor2;
    [HideInInspector] public int rootflag;

    private bool destroyFlag = false;

    //基準は2.5秒
    [SerializeField] private float invokeTime = 2.5f;
    [SerializeField] private TalkManager talkManager;
    [SerializeField] private ChoiceCursor choiceCursor;

    //trueで選択できる
    [HideInInspector]
    public bool stopChoice = true;

    //trueの場合は1Pの勝ち、falseの場合は2Pの勝ち
    [HideInInspector] public bool firstsPlayer = false;
    public int spritFirstPlayer = 0;

    private System.Action<int, int> _callback;

    public void SetSelectCallback(System.Action<int, int> callback)
    {
        _callback = callback;
    }

    #region 勝ち負け判定
    public void OnePlayerOne()
    {
        if (firstsPlayer == true)
        {
            rootflag = 1;
        }
    }
    public void OnePlayerTwo()
    {
        if (firstsPlayer == true)
        {
            rootflag = 2;
        }
    }
    public void OnePlayerThree()
    {
        if (firstsPlayer == true)
        {
            rootflag = 3;
        }
    }
    public void TwoPlayerOne()
    {
        if (firstsPlayer == false)
        {
            rootflag = 1;
        }
    }
    public void TwoPlayerTwo()
    {
        if (firstsPlayer == false)
        {
            rootflag = 2;
        }
    }
    public void TwoPlayerThree()
    {
        if (firstsPlayer == false)
        {
            rootflag = 3;
        }
    }

    private void Start()
    {
        cursor.SetActive(false);
        cursor2.SetActive(false);
    }
    #endregion
    public int FirstPlayer()
    {
        if (firstsPlayer)
            return 0;
        else
            return 1;
        //return firstsPlayer ? 0 : 1;
    }

    #region 1Pが1を押した判定
    public void PushButton()
    {

        /// <summary>
        /// ボタンを押し選択肢を選んだら
        /// それ以降ボタンを消し入力を断つ
        /// </summary>

        if (stopChoice == false && choiceCursor.RightMenu == 0 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが1を押した");
            cursor2.SetActive(false);//2pのカーソルを消す
            ChangeColor1();//他の選択肢を非表示
            TalkManager.Instance._isWait = false;
            Invoke("GetAorX", invokeTime);//AorX意外を消す
            stopChoice = true;//Playerが選択時他プレイヤーがボタンを入力不可
            firstsPlayer = true;//１Pがおした
            spritFirstPlayer = 1;//１Pがおした
            Invoke("DestroyAorX", invokeTime * 2);//この選択肢を消す
            TalkManager.Instance._isWait = true;
            LoveMetar.player1LoveMetar += 1;
            rootflag = 1;//選択肢の一番(左)
            //LoveMetar.player1LoveMetar += 5;
            //talkManager.ChoiceRoot(firstsPlayer,1);
            Debug.Log("choice1-1");
            if (_callback != null)
                _callback(0, 1);
        }


        //2Pが1を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 0 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが1を押した");
            cursor.SetActive(false);
            ChangeColor1();
            TalkManager.Instance._isWait = false;
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            spritFirstPlayer = 2;
            Invoke("DestroyAorX", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            LoveMetar.player1LoveMetar += 1;
            rootflag = 1;
            //LoveMetar.player2LoveMetar += 5;
            //talkManager.ChoiceRoot(firstsPlayer, 4);
            Debug.Log("choice2-1");
            if (_callback != null)
                _callback(1, 1);
        }

        //1Pが2を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 1 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが2を押した");
            cursor2.SetActive(false);
            ChangeColor2();
            TalkManager.Instance._isWait = false;
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            spritFirstPlayer = 1;
            Invoke("DestroyBorY", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            LoveMetar.player1LoveMetar -= 1;
            rootflag = 2;
            //talkManager.ChoiceRoot(firstsPlayer, 2);
            Debug.Log("choice1-2");
            if (_callback != null)
                _callback(0, 2);
        }

        //2Pが2を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 1 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが2を押した");
            cursor.SetActive(false);
            ChangeColor2();
            TalkManager.Instance._isWait = false;
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            spritFirstPlayer = 2;
            Invoke("DestroyBorY", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            LoveMetar.player1LoveMetar -= 1;
            rootflag = 2;
            //talkManager.ChoiceRoot(firstsPlayer, 5);
            Debug.Log("choice2-2");
            if (_callback != null)
                _callback(1, 2);
        }

        //1Pが3を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 2 && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("1Pが3を押した");
            cursor2.SetActive(false);
            ChangeColor3();
            TalkManager.Instance._isWait = false;
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = true;
            spritFirstPlayer = 1;
            Invoke("DestroyTrigger", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 3;
            LoveMetar.player1LoveMetar -= 1;
            //talkManager.ChoiceRoot(firstsPlayer, 3);
            Debug.Log("choice1-3");
            if (_callback != null)
                _callback(0, 3);
        }

        //2Pが3を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 2 && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("2Pが3を押した");
            cursor.SetActive(false);
            ChangeColor3();
            TalkManager.Instance._isWait = false;
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            firstsPlayer = false;
            spritFirstPlayer = 2;
            Invoke("DestroyTrigger", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            LoveMetar.player1LoveMetar -= 1;
            rootflag = 3;
            //talkManager.ChoiceRoot(firstsPlayer, 6);
            Debug.Log("choice2-3");
            if (_callback != null)
                _callback(1, 3);
        }
    }
    #endregion 1Pが1を押した判定
    private void Update()
    {
        DebugPushButton();
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
            TalkManager.Instance._isWait = false;
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 0;
            spritFirstPlayer = 1;
            Invoke("DestroyAorX", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 1;
            Debug.Log("choice1-1");
            if (_callback != null)
                _callback(0, 1);
        }

        //2Pが1を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが1を押した");
            cursor.SetActive(false);
            ChangeColor1();
            TalkManager.Instance._isWait = false;
            Invoke("GetAorX", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 1;
            spritFirstPlayer = 2;
            Invoke("DestroyAorX", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 1;
            Debug.Log("choice2-1");
            if (_callback != null)
                _callback(1, 1);
        }

        //1Pが2を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("1Pが2を押した");
            cursor2.SetActive(false);
            ChangeColor2();
            TalkManager.Instance._isWait = false;
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 0;
            spritFirstPlayer = 1;
            Invoke("DestroyBorY", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 2;
            Debug.Log("choice1-2");
            if (_callback != null)
                _callback(0, 2);
        }

        //2Pが2を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが2を押した");
            cursor.SetActive(false);
            ChangeColor2();
            TalkManager.Instance._isWait = false;
            Invoke("GetBorY", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 1;
            spritFirstPlayer = 2;
            Invoke("DestroyBorY", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 2;
            Debug.Log("choice2-2");
            if (_callback != null)
                _callback(1, 2);
        }

        //1Pが3を押した判定
        if (stopChoice == false && choiceCursor.RightMenu == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("1Pが3を押した");
            cursor2.SetActive(false);
            ChangeColor3();
            TalkManager.Instance._isWait = false;
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 0;
            spritFirstPlayer = 1;
            Invoke("DestroyTrigger", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 3;
            Debug.Log("choice1-3");
            if (_callback != null)
                _callback(0, 3);
        }

        //2Pが3を押した判定
        if (stopChoice == false && choiceCursor.LeftMenu == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("2Pが3を押した");
            cursor.SetActive(false);
            ChangeColor3();
            TalkManager.Instance._isWait = false;
            Invoke("GetTrigger", invokeTime);
            stopChoice = true;
            talkManager.ActiveNumber = 1;
            spritFirstPlayer = 2;
            Invoke("DestroyTrigger", invokeTime * 2);
            TalkManager.Instance._isWait = true;
            rootflag = 3;
            Debug.Log("choice2-3");
            if (_callback != null)
                _callback(1, 3);
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

    #region 押したボタン以外のボタンを消す
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
    #endregion

    public bool getStopchoice()
    {
        return stopChoice;
    }
    public bool getdestroyFlag()
    {
        return destroyFlag;
    }

    #region ボタンを消す
    private void DestroyAorX()
    {
        Destroy(choiceAorX);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
        talkManager.TextFrame.SetActive(true);
    }
    private void DestroyBorY()
    {
        Destroy(choiceBorY);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
        talkManager.TextFrame.SetActive(true);
    }
    private void DestroyTrigger()
    {
        Destroy(choiceTrigger);
        FrameText.SetActive(true);
        destroyFlag = true;
        cursor.SetActive(false);
        cursor2.SetActive(false);
        talkManager.TextFrame.SetActive(true);
    }
    #endregion

    public void SetActive()
    {
        choiceAorX.SetActive(true);
        choiceBorY.SetActive(true);
        choiceTrigger.SetActive(true);
    }
}
