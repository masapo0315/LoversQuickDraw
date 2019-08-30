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
    //
    [SerializeField] private GameObject HintFrame;
    [SerializeField] private GameObject RuluImage;
    [SerializeField] private GameObject PlaceFrame;
    [SerializeField] private SoundManager sound;
    [HideInInspector] public bool Win1P = true;

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
    //[SerializeField]private Image BackGround;

    //1図書館・2保健室・3教室
    [SerializeField] private List<Image> PlaceList = new List<Image>();
    //
    [SerializeField] private List<GameObject> buttonMenuList = new List<GameObject>();
    //ミスした時の秒数　今後実装
    //private float TimeCount = 2;
    //
    [SerializeField] private Button[] _buttons;
    //
    void Start()
    {
        Karen_Hint.GetComponent<Text>();
        Karen_Hint.text = Hint;

        //BackGround.GetComponent<Image>();
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
    //1Pが選択した
    public void OnSelect1P()
    {
        Debug.Log("OnSelect1Pを通った");
        switch (Dankai)
        {
            case 1:
                Debug.Log("1を通った");
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[0].Select();
                        break;
                    case 1:
                        _buttons[1].Select();
                        break;
                    case 2:
                        _buttons[2].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 3:
                        _buttons[3].Select();
                        break;
                    case 4:
                        _buttons[4].Select();
                        break;
                }
                break;
            case 2:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[5].Select();
                        break;
                    case 1:
                        _buttons[6].Select();
                        break;
                    case 2:
                        _buttons[7].Select();
                        break;
                    case 3:
                        _buttons[8].Select();
                        break;
                    case 4:
                        _buttons[9].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                }
                break;
            case 3:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[10].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 1:
                        _buttons[11].Select();
                        break;
                    case 2:
                        _buttons[12].Select();
                        break;
                    case 3:
                        _buttons[13].Select();
                        break;
                    case 4:
                        _buttons[14].Select();
                        break;
                }
                break;
            case 4:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[15].Select();
                        break;
                    case 1:
                        _buttons[16].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 2:
                        _buttons[17].Select();
                        break;
                    case 3:
                        _buttons[18].Select();
                        break;
                    case 4:
                        _buttons[19].Select();
                        break;
                }
                break;
            case 5:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[20].Select();
                        break;
                    case 1:
                        _buttons[21].Select();
                        break;
                    case 2:
                        _buttons[22].Select();
                        break;
                    case 3:
                        _buttons[23].Select();
                        break;
                    case 4:
                        _buttons[24].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                }
                break;
            case 6:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[25].Select();
                        break;
                    case 1:
                        _buttons[26].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 2:
                        _buttons[27].Select();
                        break;
                    case 3:
                        _buttons[28].Select();
                        break;
                    case 4:
                        _buttons[29].Select();
                        break;
                }
                break;
            case 7:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[30].Select();
                        break;
                    case 1:
                        _buttons[31].Select();
                        break;
                    case 2:
                        _buttons[32].Select();
                        break;
                    case 3:
                        _buttons[33].Select();
                        break;
                    case 4:
                        _buttons[34].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                }
                break;
            case 8:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[35].Select();
                        break;
                    case 1:
                        _buttons[36].Select();
                        break;
                    case 2:
                        _buttons[37].Select();
                        break;
                    case 3:
                        _buttons[38].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 4:
                        _buttons[39].Select();
                        break;
                }
                break;
            case 9:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[40].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 1:
                        _buttons[41].Select();
                        break;
                    case 2:
                        _buttons[42].Select();
                        break;
                    case 3:
                        _buttons[43].Select();
                        break;
                    case 4:
                        _buttons[44].Select();
                        break;
                }
                break;
            case 10:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[45].Select();
                        break;
                    case 1:
                        _buttons[46].Select();
                        break;
                    case 2:
                        _buttons[47].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 3:
                        _buttons[48].Select();
                        break;
                    case 4:
                        _buttons[49].Select();
                        break;
                }
                break;
            case 11:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[50].Select();
                        break;
                    case 1:
                        _buttons[51].Select();
                        break;
                    case 2:
                        _buttons[52].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 3:
                        _buttons[53].Select();
                        break;
                    case 4:
                        _buttons[54].Select();
                        break;
                }
                break;
            case 12:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[55].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 1:
                        _buttons[56].Select();
                        break;
                    case 2:
                        _buttons[57].Select();
                        break;
                    case 3:
                        _buttons[58].Select();
                        break;
                    case 4:
                        _buttons[59].Select();
                        break;
                }
                break;
            case 13:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[60].Select();
                        break;
                    case 1:
                        _buttons[61].Select();
                        break;
                    case 2:
                        _buttons[62].Select();
                        break;
                    case 3:
                        _buttons[63].Select();
                        break;
                    case 4:
                        _buttons[64].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                }
                break;
            case 14:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[65].Select();
                        break;
                    case 1:
                        _buttons[66].Select();
                        break;
                    case 2:
                        _buttons[67].Select();
                        break;
                    case 3:
                        _buttons[68].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 4:
                        _buttons[69].Select();
                        break;
                }
                break;
            case 15:
                switch (playerCursorController.Player1Menu)
                {
                    case 0:
                        _buttons[70].Select();
                        break;
                    case 1:
                        _buttons[71].Select();
                        Select1P++;
                        Debug.Log(Select1P);
                        break;
                    case 2:
                        _buttons[72].Select();
                        break;
                    case 3:
                        _buttons[73].Select();
                        break;
                    case 4:
                        _buttons[74].Select();
                        break;
                }
                break;
        }
    }
    //2Pが選択した
    public void OnSelect2P()
    {
        Debug.Log("OnSelect2Pを通った");
        switch (Dankai)
        {
            case 1:
                Debug.Log("1を通った");
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[0].Select();
                        break;
                    case 1:
                        _buttons[1].Select();
                        break;
                    case 2:
                        _buttons[2].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 3:
                        _buttons[3].Select();
                        break;
                    case 4:
                        _buttons[4].Select();
                        break;
                }
                break;
            case 2:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[5].Select();
                        break;
                    case 1:
                        _buttons[6].Select();
                        break;
                    case 2:
                        _buttons[7].Select();
                        break;
                    case 3:
                        _buttons[8].Select();
                        break;
                    case 4:
                        _buttons[9].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                }
                break;
            case 3:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[10].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 1:
                        _buttons[11].Select();
                        break;
                    case 2:
                        _buttons[12].Select();
                        break;
                    case 3:
                        _buttons[13].Select();
                        break;
                    case 4:
                        _buttons[14].Select();
                        break;
                }
                break;
            case 4:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[15].Select();
                        break;
                    case 1:
                        _buttons[16].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 2:
                        _buttons[17].Select();
                        break;
                    case 3:
                        _buttons[18].Select();
                        break;
                    case 4:
                        _buttons[19].Select();
                        break;
                }
                break;
            case 5:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[20].Select();
                        break;
                    case 1:
                        _buttons[21].Select();
                        break;
                    case 2:
                        _buttons[22].Select();
                        break;
                    case 3:
                        _buttons[23].Select();
                        break;
                    case 4:
                        _buttons[24].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                }
                break;
            case 6:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[25].Select();
                        break;
                    case 1:
                        _buttons[26].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 2:
                        _buttons[27].Select();
                        break;
                    case 3:
                        _buttons[28].Select();
                        break;
                    case 4:
                        _buttons[29].Select();
                        break;
                }
                break;
            case 7:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[30].Select();
                        break;
                    case 1:
                        _buttons[31].Select();
                        break;
                    case 2:
                        _buttons[32].Select();
                        break;
                    case 3:
                        _buttons[33].Select();
                        break;
                    case 4:
                        _buttons[34].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                }
                break;
            case 8:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[35].Select();
                        break;
                    case 1:
                        _buttons[36].Select();
                        break;
                    case 2:
                        _buttons[37].Select();
                        break;
                    case 3:
                        _buttons[38].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 4:
                        _buttons[39].Select();
                        break;
                }
                break;
            case 9:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[40].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 1:
                        _buttons[41].Select();
                        break;
                    case 2:
                        _buttons[42].Select();
                        break;
                    case 3:
                        _buttons[43].Select();
                        break;
                    case 4:
                        _buttons[44].Select();
                        break;
                }
                break;
            case 10:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[45].Select();
                        break;
                    case 1:
                        _buttons[46].Select();
                        break;
                    case 2:
                        _buttons[47].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 3:
                        _buttons[48].Select();
                        break;
                    case 4:
                        _buttons[49].Select();
                        break;
                }
                break;
            case 11:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[50].Select();
                        break;
                    case 1:
                        _buttons[51].Select();
                        break;
                    case 2:
                        _buttons[52].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 3:
                        _buttons[53].Select();
                        break;
                    case 4:
                        _buttons[54].Select();
                        break;
                }
                break;
            case 12:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[55].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 1:
                        _buttons[56].Select();
                        break;
                    case 2:
                        _buttons[57].Select();
                        break;
                    case 3:
                        _buttons[58].Select();
                        break;
                    case 4:
                        _buttons[59].Select();
                        break;
                }
                break;
            case 13:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[60].Select();
                        break;
                    case 1:
                        _buttons[61].Select();
                        break;
                    case 2:
                        _buttons[62].Select();
                        break;
                    case 3:
                        _buttons[63].Select();
                        break;
                    case 4:
                        _buttons[64].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                }
                break;
            case 14:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[65].Select();
                        break;
                    case 1:
                        _buttons[66].Select();
                        break;
                    case 2:
                        _buttons[67].Select();
                        break;
                    case 3:
                        _buttons[68].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 4:
                        _buttons[69].Select();
                        break;
                }
                break;
            case 15:
                switch (playerCursorController.Player2Menu)
                {
                    case 0:
                        _buttons[70].Select();
                        break;
                    case 1:
                        _buttons[71].Select();
                        Select2P++;
                        Debug.Log(Select2P);
                        break;
                    case 2:
                        _buttons[72].Select();
                        break;
                    case 3:
                        _buttons[73].Select();
                        break;
                    case 4:
                        _buttons[74].Select();
                        break;
                }
                break;
        }
    }
    //
    public void ClickTrue()
    {
        sound.SESounds(0, 0.5f);
        //Debug.Log("押すまで来た");
        switch (Dankai)
        {
            case 1:
                Debug.Log("1回目");
                Karen = "と";
                Destroy(buttonMenuList[0]);
                break;
            case 2:
                Debug.Log("2回目");
                Karen = "し";
                Destroy(buttonMenuList[1]);
                break;
            case 3:
                Debug.Log("3回目");
                Karen = "ょ";
                Destroy(buttonMenuList[2]);
                break;
            case 4:
                Debug.Log("4回目");
                Karen = "か";
                Destroy(buttonMenuList[3]);
                break;
            case 5:
                Debug.Log("5回目");
                Karen = "ん";
                Destroy(buttonMenuList[4]);

                //一度クリアにする関数
                //Destroy(PlaceList[0]);
                _fill = true;
                //PlaceList[0].fillAmount -= Time.deltaTime;
                Destroy(buttonMenuList[1]);
                Invoke("ResetText", 1);
                TimeLag();
                Invoke("ReadyGO", 1.0f);
                Hint = "そのあとは体調悪い時に\n行くところに行って...";
                break;
            case 6:
                Debug.Log("6回目");
                Karen = "ほ";
                Destroy(buttonMenuList[5]);
                break;
            case 7:
                Debug.Log("7回目");
                Karen = "け";
                Destroy(buttonMenuList[6]);
                break;
            case 8:
                Debug.Log("8回目");
                Karen = "ん";
                Destroy(buttonMenuList[7]);
                break;
            case 9:
                Debug.Log("9回目");
                Karen = "し";
                Destroy(buttonMenuList[8]);
                break;
            case 10:
                Debug.Log("10回目");
                Karen = "つ";
                Destroy(buttonMenuList[9]);
                
                //一度クリアにする関数
                _fill = true;
                TimeLag();
                Invoke("ReadyGO", 1.0f);
                Invoke("ResetText", 1);
                Hint = "それで2人に会った\n場所に来たんだよね";
                break;
            case 11:
                Debug.Log("11回目");
                Karen = "き";
                Destroy(buttonMenuList[10]);
                break;
            case 12:
                Debug.Log("12回目");
                Karen = "ょ";
                Destroy(buttonMenuList[11]);
                break;
            case 13:
                Debug.Log("13回目");
                Karen = "う";
                Destroy(buttonMenuList[12]);
                break;
            case 14:
                Debug.Log("14回目");
                Karen = "し";
                Destroy(buttonMenuList[13]);
                break;
            case 15:
                Debug.Log("15回目");
                Karen = "つ";
                Destroy(buttonMenuList[14]);

                _fill = true;
                VictoryPlayer();
                Invoke("DestroyPlace", 1);
                Destroy(HintFrame);
                Invoke("Scene", 2);
                TimeLag();
                break;
        }
        Text();
    }
    //
    private void Text()
    {
        ChangeText();
        Dankai++;
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

    /*
    public void Clickfalse()
    {
        if (playerCursorController.GetColor == true)
        {
            false1P();
        }
        else if (playerCursorController.GetColor == false)
        {
            false2P();
        }
    }
    */

    private void ResetText()
    {
        Debug.Log("リセット");

        Place0.text = "";
        Place1.text = "";
        Place2.text = "";
        Place3.text = "";
        Place4.text = "";

        Debug.Log(Karen);
        //ChangeText();
        //_fill = false;
    }
    //仮
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
        if (Input.GetKeyDown(KeyCode.Space))
        //if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            RuleCheck1 = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        //if (OVRInput.GetDown(OVRInput.RawButton.X))
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
        Debug.Log("まれいたそ");
        Ready2 = false;
    }

    private void ImageFill()
    {switch (Dankai)
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