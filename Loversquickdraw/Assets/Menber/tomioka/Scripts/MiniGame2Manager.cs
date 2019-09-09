using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2Manager : MonoBehaviour
{
    //問題の答えが入るテキスト(保健室、図書館、教室)
    [SerializeField] private Text _place1;
    [SerializeField] private Text _place2;
    [SerializeField] private Text _place3;
    [SerializeField] private Text _place4;
    [SerializeField] private Text _place0;
    [SerializeField] private Text _karenHint;

    [SerializeField] private GameObject _hintFrame;
    [SerializeField] private GameObject _ruluImage;
    [SerializeField] private GameObject _placeFrame;
    [SerializeField] private GameObject _readyImage;
    [SerializeField] private GameObject _goImage;

    [SerializeField] private PlayerCursorController playerCursorController;
    [SerializeField] private SoundManager sound;
    [SerializeField] private TalkManager talkManager;

    private bool _ruleAfter = false;
    private bool _switchJudg = false;
    private bool _ruleCheck1, _ruleCheck2 = false;
    private bool _fill = false;

    //[HideInInspector]
    public bool _ready1, _ready2 = false;

    private string _hint = "この教室に来る前は\n本が沢山あるところにいて...";
    private string _karen;
    private int _dankai = 1;

    //1Pと2Pがとった文字数
    private int _select1P, _select2P = 0;

    //ミスした時の秒数　今後実装
    private float _penaltyTime = 2.0f;

    [SerializeField] private int _lovePoint = 5;

    //1図書館・2保健室・3教室
    [SerializeField] private List<Image> _placeList = new List<Image>();
    [SerializeField] private List<GameObject> _buttonMenuList = new List<GameObject>();

    void Start()
    {
        _readyImage.SetActive(false);
        _goImage.SetActive(false);
        _karenHint.GetComponent<Text>();
        _karenHint.text = _hint;
    }

    void Update()
    {
        if (_ruleAfter == false)
        {
            RuleCheck();
        }
        ImageFill();
    }

    private void ChangeText()
    {
        _place1.GetComponent<Text>();
        _place2.GetComponent<Text>();
        _place3.GetComponent<Text>();
        _place4.GetComponent<Text>();
        _place0.GetComponent<Text>();

        switch (_dankai % 5)
        {
            case 0:
                _place0.text = _karen;
                if (playerCursorController._getColor == true)
                {
                    //1Pの色
                    _place0.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    //2Pの色
                    _place0.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 1:
                _place1.text = _karen;
                if (playerCursorController._getColor == true)
                {
                    _place1.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    _place1.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 2:
                _place2.text = _karen;
                if (playerCursorController._getColor == true)
                {
                    _place2.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    _place2.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 3:
                _place3.text = _karen;
                if (playerCursorController._getColor == true)
                {
                    _place3.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    _place3.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;
            case 4:
                _place4.text = _karen;
                if (playerCursorController._getColor == true)
                {
                    _place4.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                }
                else
                {
                    _place4.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
                }
                break;

        }

        _karenHint.GetComponent<Text>();
        _karenHint.text = _hint;
    }

    public void SelectSwitch1P()
    {
        switch (_dankai)
        {
            case 1:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        false1P();
                        break;

                    case 2:
                        Debug.Log("1回目");
                        True();
                        _karen = "と";
                        Destroy(_buttonMenuList[0]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 2:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false1P();
                        break;

                    case 4:
                        Debug.Log("2回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[1]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 3:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                        Debug.Log("3回目");
                        True();
                        _karen = "ょ";
                        Destroy(_buttonMenuList[2]);
                        _switchJudg = true;
                        _select1P++;
                        break;

                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;
                }
                break;

            case 4:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;

                    case 1:
                        Debug.Log("4回目");
                        True();
                        _karen = "か";
                        Destroy(_buttonMenuList[3]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 5:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false1P();
                        break;

                    case 4:
                        Debug.Log("5回目");
                        True();
                        _karen = "ん";
                        Destroy(_buttonMenuList[4]);
                        _switchJudg = true;
                        _select1P++;

                        //一度クリアにする関数
                        _fill = true;
                        Destroy(_buttonMenuList[1]);
                        Invoke("ResetText", 1);
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        _hint = "そのあとは体調悪い時に\n行くところに行って...";
                        break;
                }
                break;

            case 6:
                switch (playerCursorController._player1Menu)
                {
                    case 1:
                        Debug.Log("6回目");
                        True();
                        _karen = "ほ";
                        Destroy(_buttonMenuList[5]);
                        _switchJudg = true;
                        _select1P++;
                        break;

                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;
                }
                break;

            case 7:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false1P();
                        break;

                    case 4:
                        Debug.Log("7回目");
                        True();
                        _karen = "け";
                        Destroy(_buttonMenuList[6]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 8:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false1P();
                        break;

                    case 3:
                        Debug.Log("8回目");
                        True();
                        _karen = "ん";
                        Destroy(_buttonMenuList[7]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 9:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                        Debug.Log("9回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[8]);
                        _switchJudg = true;
                        _select1P++;
                        break;

                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;
                }
                break;

            case 10:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        false1P();
                        break;

                    case 2:
                        Debug.Log("10回目");
                        True();
                        _karen = "つ";
                        Destroy(_buttonMenuList[9]);
                        _switchJudg = true;
                        _select1P++;

                        //一度クリアにする関数
                        _fill = true;
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Invoke("ResetText", 1);
                        _hint = "それで2人に会った\n場所に来たんだよね";
                        break;
                }
                break;

            case 11:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false1P();
                        break;

                    case 3:
                        Debug.Log("11回目");
                        True();
                        _karen = "き";
                        Destroy(_buttonMenuList[10]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 12:
                switch (playerCursorController._player1Menu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;

                    case 0:
                        Debug.Log("12回目");
                        True();
                        _karen = "ょ";
                        Destroy(_buttonMenuList[11]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 13:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false1P();
                        break;

                    case 4:
                        Debug.Log("13回目");
                        True();
                        _karen = "う";
                        Destroy(_buttonMenuList[12]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 14:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false1P();
                        break;

                    case 3:
                        Debug.Log("14回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[13]);
                        _switchJudg = true;
                        _select1P++;
                        break;
                }
                break;

            case 15:
                switch (playerCursorController._player1Menu)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false1P();
                        break;

                    case 1:
                        Debug.Log("15回目");
                        True();
                        _karen = "つ";
                        Destroy(_buttonMenuList[14]);
                        _switchJudg = true;
                        _select1P++;

                        _fill = true;
                        VictoryPlayer();
                        Invoke("DestroyPlace", 1);
                        Destroy(_hintFrame);
                        Invoke("Scene", 2);
                        TimeLag();
                        break;
                }
                break;
        }
        Text();
    }

    public void SelectSwitch2P()
    {
        switch (_dankai)
        {
            case 1:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        false2P();
                        break;

                    case 2:
                        Debug.Log("1回目");
                        True();
                        _karen = "と";
                        Destroy(_buttonMenuList[0]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 2:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false2P();
                        break;

                    case 4:
                        Debug.Log("2回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[1]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 3:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                        Debug.Log("3回目");
                        True();
                        _karen = "ょ";
                        Destroy(_buttonMenuList[2]);
                        _switchJudg = true;
                        _select2P++;
                        break;

                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;
                }
                break;

            case 4:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;

                    case 1:
                        Debug.Log("4回目");
                        True();
                        _karen = "か";
                        Destroy(_buttonMenuList[3]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 5:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false2P();
                        break;

                    case 4:
                        Debug.Log("5回目");
                        True();
                        _karen = "ん";
                        Destroy(_buttonMenuList[4]);
                        _switchJudg = true;
                        _select2P++;

                        //一度クリアにする関数
                        _fill = true;
                        Destroy(_buttonMenuList[1]);
                        Invoke("ResetText", 1);
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        _hint = "そのあとは体調悪い時に\n行くところに行って...";
                        break;
                }
                break;

            case 6:
                switch (playerCursorController._player2Menu)
                {
                    case 1:
                        Debug.Log("6回目");
                        True();
                        _karen = "ほ";
                        Destroy(_buttonMenuList[5]);
                        _switchJudg = true;
                        _select2P++;
                        break;

                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;
                }
                break;

            case 7:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false2P();
                        break;

                    case 4:
                        Debug.Log("7回目");
                        True();
                        _karen = "け";
                        Destroy(_buttonMenuList[6]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 8:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false2P();
                        break;

                    case 3:
                        Debug.Log("8回目");
                        True();
                        _karen = "ん";
                        Destroy(_buttonMenuList[7]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 9:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                        Debug.Log("9回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[8]);
                        _switchJudg = true;
                        _select2P++;
                        break;

                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;
                }
                break;

            case 10:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        false2P();
                        break;

                    case 2:
                        Debug.Log("10回目");
                        True();
                        _karen = "つ";
                        Destroy(_buttonMenuList[9]);
                        _switchJudg = true;
                        _select2P++;

                        //一度クリアにする関数
                        _fill = true;
                        TimeLag();
                        Invoke("ReadyGO", 1.0f);
                        Invoke("ResetText", 1);
                        _hint = "それで2人に会った\n場所に来たんだよね";
                        break;
                }
                break;

            case 11:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false2P();
                        break;

                    case 3:
                        Debug.Log("11回目");
                        True();
                        _karen = "き";
                        Destroy(_buttonMenuList[10]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 12:
                switch (playerCursorController._player2Menu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;

                    case 0:
                        Debug.Log("12回目");
                        True();
                        _karen = "ょ";
                        Destroy(_buttonMenuList[11]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 13:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        false2P();
                        break;

                    case 4:
                        Debug.Log("13回目");
                        True();
                        _karen = "う";
                        Destroy(_buttonMenuList[12]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 14:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 4:
                        false2P();
                        break;

                    case 3:
                        Debug.Log("14回目");
                        True();
                        _karen = "し";
                        Destroy(_buttonMenuList[13]);
                        _switchJudg = true;
                        _select2P++;
                        break;
                }
                break;

            case 15:
                switch (playerCursorController._player2Menu)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        false2P();
                        break;

                    case 1:
                        Debug.Log("15回目");
                        True();
                        _karen = "つ";
                        Destroy(_buttonMenuList[14]);
                        _switchJudg = true;
                        _select2P++;

                        _fill = true;
                        VictoryPlayer();
                        Invoke("DestroyPlace", 1);
                        Destroy(_hintFrame);
                        Invoke("Scene", 2);
                        TimeLag();
                        break;
                }
                break;
        }
        Text();
    }

    private void Text()
    {
        if (_switchJudg == true)
        {
            ChangeText();
            _dankai++;
            _switchJudg = false;
        }
    }

    private void True()
    {
        sound.SESounds(0, 0.5f);
    }

    private void false1P()
    {
        if (_ruleAfter == true)
        {
            Penalty1P();
            Debug.Log("1P失敗");
            sound.SESounds(1, 0.5f);
            Invoke("PenaltyEnd1P", _penaltyTime);
        }
    }

    private void false2P()
    {
        if (_ruleAfter == true)
        {
            Penalty2P();
            Debug.Log("2P失敗");
            sound.SESounds(1, 0.5f);
            Invoke("PenaltyEnd2P", _penaltyTime);
        }
    }

    private void ResetText()
    {
        Debug.Log("リセット");
        _place0.text = "";
        _place1.text = "";
        _place2.text = "";
        _place3.text = "";
        _place4.text = "";
        Debug.Log(_karen);
    }

    private void Scene()
    {
        //告白パートに飛ぶ
        SceneLoadManager.LoadScene("Title");
    }

    private void DestroyPlace()
    {
        Destroy(_place1);
        Destroy(_place2);
        Destroy(_place3);
        Destroy(_place4);
        Destroy(_place0);
        Destroy(_placeFrame);
        playerCursorController._cursor1.SetActive(false);
        playerCursorController._cursor2.SetActive(false);
    }

    private void VictoryPlayer()
    {
        Debug.Log(_select1P);
        Debug.Log(_select2P);
        if (_select1P > _select2P)
        {
            talkManager.ActiveNumber = 0;
            LoveMetar.player1LoveMetar += 5;
            Debug.Log("1Pの勝ち");
        }
        else
        {
            talkManager.ActiveNumber = 1;
            LoveMetar.player2LoveMetar += 5;
            Debug.Log("2Pの勝ち");
        }
    }

    private void RuleCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.A))
        {
            _ruleCheck1 = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            _ruleCheck2 = true;
        }

        if (_ruleCheck1 == true && _ruleCheck2 == true)
        {
            _ruluImage.SetActive(false);
            _ruleAfter = true;
            SetReady();
            Invoke("SetGo", 2.0f);
            Invoke("ImageOff", 4.0f);
        }
    }

    private void ReadyGO()
    {
        _ready1 = true;
        _ready2 = true;
    }

    private void TimeLag()
    {
        Penalty1P();
        Penalty2P();
    }

    private void Penalty1P()
    {
        _ready1 = false;
    }

    private void Penalty2P()
    {
        _ready2 = false;
    }

    private void PenaltyEnd1P()
    {
        _ready1 = true;
    }

    private void PenaltyEnd2P()
    {
        _ready2 = true;
    }

    private void ImageFill()
    {
        switch (_dankai)
        {
            case 6:
                _placeList[0].fillAmount -= Time.deltaTime;
                break;
            case 11:
                _placeList[1].fillAmount -= Time.deltaTime;
                break;
            case 16:
                _placeList[2].fillAmount -= Time.deltaTime;
                break;
        }
    }

    private void SetReady()
    {
        _readyImage.SetActive(true);
    }

    private void SetGo()
    {
        _readyImage.SetActive(false);
        _goImage.SetActive(true);
    }

    private void ImageOff()
    {
        _goImage.SetActive(false);
        ReadyGO();
    }
}