using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGame2Manager : MonoBehaviour
{
    //korehairetu
    //問題の答えが入るテキスト(保健室、図書館、教室)
    [SerializeField] private Text Place1;
    [SerializeField] private Text Place2;
    [SerializeField] private Text Place3;
    [SerializeField] private Text Place4;
    [SerializeField] private Text Place0;
    [SerializeField] private Text Karen_Hint;

    [SerializeField] private GameObject HintFrame;
    [SerializeField] private GameObject RuluImage;
    [SerializeField] private GameObject PlaceFrame;
    [SerializeField] private SoundManager sound;
    [HideInInspector] public bool Win1P = true;

    private bool SwitchJudg = false;

    private bool RuleCheck1, RuleCheck2 = false;
    //ReadyGoまで操作できないように
    //[HideInInspector]
    public bool Ready1, Ready2 = false;

    private bool _fill = false;

    private string Hint = "この教室に来る前は\n本が沢山あるところにいて...";
    private string Karen;
    private int Dankai = 1;

    //1Pと2Pがとった文字数
    private int Select1P, Select2P = 0;

    [SerializeField] private PlayerCursorController playerCursorController;

    //1図書館・2保健室・3教室
    [SerializeField] private List<Image> PlaceList = new List<Image>();
    [SerializeField] private List<GameObject> buttonMenuList = new List<GameObject>();
    //ミスした時の秒数　今後実装
    //private float TimeCount = 2;

    void Start()
    {
        Karen_Hint.GetComponent<Text>();
        Karen_Hint.text = Hint;
    }

    void Update()
    {
        //RuleCheck();
        ImageFill();
    }

    private void ChangeText()
    {
        Place1.GetComponent<Text>();
        Place2.GetComponent<Text>();
        Place3.GetComponent<Text>();
        Place4.GetComponent<Text>();
        Place0.GetComponent<Text>();

        switch (Dankai % 5)
        {
            case 0:
                Place0.text = Karen;
                if (playerCursorController.GetColor == true)
                {
                    //1Pの色
                    Place0.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    //2Pの色
                    Place0.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 1:
                Place1.text = Karen;
                if (playerCursorController.GetColor == true)
                {
                    Place1.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    Place1.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 2:
                Place2.text = Karen;
                if (playerCursorController.GetColor == true)
                {
                    Place2.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    Place2.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 3:
                Place3.text = Karen;
                if (playerCursorController.GetColor == true)
                {
                    Place3.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    Place3.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 4:
                Place4.text = Karen;
                if (playerCursorController.GetColor == true)
                {
                    Place4.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    Place4.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;

        }

        Karen_Hint.GetComponent<Text>();
        Karen_Hint.text = Hint;
    }

    public void SelectSwitch()
    {
        switch (Dankai)
        {
            case 1:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        break;

                    case 1:

                        break;

                    case 2:
                        Debug.Log("1回目");
                        Karen = "と";
                        Destroy(buttonMenuList[0]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 2:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("2回目");
                        Karen = "し";
                        Destroy(buttonMenuList[1]);
                        SwitchJudg = true;
                        Select1P++;
                        break;
                }
                break;

            case 3:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        Debug.Log("3回目");
                        Karen = "ょ";
                        Destroy(buttonMenuList[2]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 4:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("4回目");
                        Karen = "か";
                        Destroy(buttonMenuList[3]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 5:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("5回目");
                        Karen = "ん";
                        Destroy(buttonMenuList[4]);
                        SwitchJudg = true;
                        Select1P++;

                        //一度クリアにする関数
                        _fill = true;
                        Destroy(buttonMenuList[1]);
                        Invoke("ResetText", 1);
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Hint = "そのあとは体調悪い時に\n行くところに行って...";
                        break;
                }
                break;

            case 6:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("6回目");
                        Karen = "ほ";
                        Destroy(buttonMenuList[5]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 7:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("7回目");
                        Karen = "け";
                        Destroy(buttonMenuList[6]);
                        SwitchJudg = true;
                        Select1P++;
                        break;
                }
                break;

            case 8:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("8回目");
                        Karen = "ん";
                        Destroy(buttonMenuList[7]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 4:
                        break;
                }
                break;

            case 9:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        Debug.Log("9回目");
                        Karen = "し";
                        Destroy(buttonMenuList[8]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 10:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:
                        Debug.Log("10回目");
                        Karen = "つ";
                        Destroy(buttonMenuList[9]);
                        SwitchJudg = true;
                        Select1P++;

                        //一度クリアにする関数
                        _fill = true;
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Invoke("ResetText", 1);
                        Hint = "それで2人に会った\n場所に来たんだよね";
                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 11:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("11回目");
                        Karen = "き";
                        Destroy(buttonMenuList[10]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 4:
                        break;
                }
                break;

            case 12:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        Debug.Log("12回目");
                        Karen = "ょ";
                        Destroy(buttonMenuList[11]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 13:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("13回目");
                        Karen = "う";
                        Destroy(buttonMenuList[12]);
                        SwitchJudg = true;
                        Select1P++;
                        break;
                }
                break;

            case 14:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("14回目");
                        Karen = "し";
                        Destroy(buttonMenuList[13]);
                        SwitchJudg = true;
                        Select1P++;
                        break;

                    case 4:

                        break;
                }
                break;

            case 15:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("15回目");
                        Karen = "つ";
                        Destroy(buttonMenuList[14]);
                        SwitchJudg = true;
                        Select1P++;

                        _fill = true;
                        VictoryPlayer();
                        Invoke("DestroyPlace", 1);
                        Destroy(HintFrame);
                        Invoke("Scene", 2);
                        TimeLag();
                        break;
                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;
        }
        Text();
    }

    public void SelectSwitch2P()
    {
        switch (Dankai)
        {
            case 1:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        break;

                    case 1:

                        break;

                    case 2:
                        Debug.Log("1回目");
                        Karen = "と";
                        Destroy(buttonMenuList[0]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 2:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("2回目");
                        Karen = "し";
                        Destroy(buttonMenuList[1]);
                        SwitchJudg = true;
                        Select2P++;
                        break;
                }
                break;

            case 3:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        Debug.Log("3回目");
                        Karen = "ょ";
                        Destroy(buttonMenuList[2]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 4:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("4回目");
                        Karen = "か";
                        Destroy(buttonMenuList[3]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 5:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("5回目");
                        Karen = "ん";
                        Destroy(buttonMenuList[4]);
                        SwitchJudg = true;
                        Select2P++;

                        //一度クリアにする関数
                        _fill = true;
                        Destroy(buttonMenuList[1]);
                        Invoke("ResetText", 1);
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Hint = "そのあとは体調悪い時に\n行くところに行って...";
                        break;
                }
                break;

            case 6:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("6回目");
                        Karen = "ほ";
                        Destroy(buttonMenuList[5]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 7:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("7回目");
                        Karen = "け";
                        Destroy(buttonMenuList[6]);
                        SwitchJudg = true;
                        Select2P++;
                        break;
                }
                break;

            case 8:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("8回目");
                        Karen = "ん";
                        Destroy(buttonMenuList[7]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 4:
                        break;
                }
                break;

            case 9:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        Debug.Log("9回目");
                        Karen = "し";
                        Destroy(buttonMenuList[8]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 10:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:
                        Debug.Log("10回目");
                        Karen = "つ";
                        Destroy(buttonMenuList[9]);
                        SwitchJudg = true;
                        Select2P++;

                        //一度クリアにする関数
                        _fill = true;
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Invoke("ResetText", 1);
                        Hint = "それで2人に会った\n場所に来たんだよね";
                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 11:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("11回目");
                        Karen = "き";
                        Destroy(buttonMenuList[10]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 4:
                        break;
                }
                break;

            case 12:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        Debug.Log("12回目");
                        Karen = "ょ";
                        Destroy(buttonMenuList[11]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;

            case 13:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        Debug.Log("13回目");
                        Karen = "う";
                        Destroy(buttonMenuList[12]);
                        SwitchJudg = true;
                        Select2P++;
                        break;
                }
                break;

            case 14:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Debug.Log("14回目");
                        Karen = "し";
                        Destroy(buttonMenuList[13]);
                        SwitchJudg = true;
                        Select2P++;
                        break;

                    case 4:

                        break;
                }
                break;

            case 15:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:

                        break;

                    case 1:
                        Debug.Log("15回目");
                        Karen = "つ";
                        Destroy(buttonMenuList[14]);
                        SwitchJudg = true;
                        Select2P++;

                        _fill = true;
                        VictoryPlayer();
                        Invoke("DestroyPlace", 1);
                        Destroy(HintFrame);
                        Invoke("Scene", 2);
                        TimeLag();
                        break;
                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;
                }
                break;
        }
        Text();
    }

    private void Text()
    {
        ChangeText();
        if (SwitchJudg == true)
        {
            Dankai++;
            SwitchJudg = false;
        }
    }

    public void false1P()
    {
        Debug.Log("1P失敗");
        sound.SESounds(1, 0.5f);
    }

    public void false2P()
    {
        Debug.Log("2P失敗");
        sound.SESounds(1, 0.5f);
    }

    private void ResetText()
    {
        Debug.Log("リセット");
        Place0.text = "";
        Place1.text = "";
        Place2.text = "";
        Place3.text = "";
        Place4.text = "";
        Debug.Log(Karen);
    }

    private void Scene()
    {
        SceneLoadManager.LoadScene("Title");
    }

    private void DestroyPlace()
    {
        Destroy(Place1);
        Destroy(Place2);
        Destroy(Place3);
        Destroy(Place4);
        Destroy(Place0);
        Destroy(PlaceFrame);
        playerCursorController.Cursor1.SetActive(false);
        playerCursorController.Cursor2.SetActive(false);
    }

    private void VictoryPlayer()
    {
        Debug.Log(Select1P);
        Debug.Log(Select2P);
        if (Select1P > Select2P)
        {
            Win1P = true;
            Debug.Log("1Pの勝ち");
        }
        else
        {
            Win1P = false;
            Debug.Log("2Pの勝ち");
        }
    }

    private void RuleCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.A))
        {
            RuleCheck1 = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            RuleCheck2 = true;
        }

        if (RuleCheck1 == true && RuleCheck2 == true)
        {
            RuluImage.SetActive(false);
            ReadyGO();
        }
    }

    private void ReadyGO()
    {
        Ready1 = true;
        Ready2 = true;
    }

    private void TimeLag()
    {
        Ready1 = false;
        Ready2 = false;
    }

    private void ImageFill()
    {
        switch (Dankai)
        {
            case 6:
                PlaceList[0].fillAmount -= Time.deltaTime;
                break;
            case 11:
                PlaceList[1].fillAmount -= Time.deltaTime;
                break;
            case 16:
                PlaceList[2].fillAmount -= Time.deltaTime;
                break;
        }
    }
}