using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    public int Talktext = 0; //縦
    private new int name = 0; //横
    private float fadeInOut; //点滅用
    public bool choiceAfterText = true; //選択後のシナリオ遷移
    private bool choice = false;
    private int judgePlayer = 0;
    private int stringCount;

    //テキスト関連
    [Header("テキスト")]
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _message;
    [SerializeField]
    private string ScenarioDataName;
    [SerializeField]
    private Text _text;

    [SerializeField]
    private ChoiceControl _choiceControl;
    private string[] msgs2 = { "#select", "1", "2", "3" };
    private bool _isSelectMessege = false;

    private List<string> _loadTextData = new List<string>();
    private int _nowTextLine = 0;
    private bool _isLoadEnd = false;
    private bool _isWait = false;
    private bool _isMessageDisp = false;
    private bool _isCharacterText = false;
    //private bool 

    [SerializeField]
    private float _dispSpeed = 1.0f;
    private float _timer = 0;
    private int _stringCount = 0;

    //参照するものをインスペクター上に表示
    [SerializeField] private List<Sprite> FaceList = new List<Sprite>();
    [SerializeField] private List<Sprite> PlayerList = new List<Sprite>();
    [SerializeField] private List<Sprite> PlayerList2 = new List<Sprite>();
    [SerializeField] private GameObject Karen1; //最初のSetActive用
    [SerializeField] private GameObject Player3; //最初のSetActive用
    [SerializeField] private GameObject Player4; //最初のSetActive用
    [SerializeField] private Image Karen;
    [SerializeField] private Image Player;
    [SerializeField] private Image Player2;
    [SerializeField] private float fade;
    [SerializeField] private GameObject TextFrame;
    [SerializeField] private ChoiceManager ChoiceManager;
    //[SerializeField] private GameObject NameTextmanager;
    //[SerializeField] private GameObject CommentTextmanager;
    [SerializeField] private GameObject Sakura;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject cursor2;


    private void Start()
    {
        _nowTextLine = 0;
        _isLoadEnd = false;
        LoadFile(Application.dataPath + "/Scenario/" + ScenarioDataName + ".txt");
        //string x = "プレイヤー１";
        //x = x.Replace("プレイヤー１", "name1");
        sakuraStart();
    }


    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {
        //if (choice == true)
        //{
        //    ChoiceManager.PushButton();
        //    if (ChoiceManager.getdestroyFlag())
        //    {
        //        choice = false;
        //    }
        //}
        TextMove();

        if (_isLoadEnd)
        {
            if (_isMessageDisp)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    _isMessageDisp = false;
                    _stringCount = 1;
                    _timer = 0;
                    _text.text = _message.text.Substring(0, _stringCount);
                    StartCoroutine(TextDispCoroutine());
                }
            }
            else if (!_isWait)
            {
                ScenarioAction();
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
            {
                _isWait = false;
            }
        }
    }
    private void TextMove()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!choice)
            {
                //次に進める用の点滅終了
                sakuraOut();
                TextFrame.SetActive(true);

                //次に進める用の点滅開始
                sakuraStart();
            }
        }
    }

    #region 桜のstart,stop,fadeのspeed
    private void sakuraStart()
    {
        //テキストが出終わったら点滅開始
        for (int i = 0; i < 45; i++)
        {
            StartCoroutine("SakuraOut");
        }
    }

    private void sakuraOut()
    {
        //前回の点滅の処理を止める
        for (int i = 0; i < 45; i++)
        {
            StopCoroutine("SakuraOut");
        }
    }

    //透明度を1~0と0~1へと徐々に変更することにより点滅させる(fadein,fadeoutの要領)
    IEnumerator SakuraOut()
    {
        while (true)
        {
            //fadein
            while (fadeInOut <= 1)
            {
                Sakura.GetComponent<Image>().color += new Color(0, 0, 0, fade);
                fadeInOut += fade;
                yield return null;
            }
            //fadeout
            while (fadeInOut >= 0)
            {
                Sakura.GetComponent<Image>().color -= new Color(0, 0, 0, fade);
                fadeInOut -= fade;
                yield return null;
            }
        }
    }
    #endregion 桜の点滅

    //選択したプレイヤー、非選択のプレイヤーをtrueとfalseで管理
    #region
    private string JudgeChoice(string Player1, string Player2)
    {
        Debug.Log(ChoiceManager.firstsPlayer);
        Debug.Log(ChoiceManager.stopChoice);
        if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == true)
        {
            //１pが選択した
            Debug.Log("１がjudgedChoiceを通った");
            judgePlayer = 1;
            return Player1;
        }
        else if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == false)
        {
            //２pが選択出来なかった
            Debug.Log("２がjudgedChoiceを通った");
            judgePlayer = 2;
            return Player2;
        }

        else return "通ってない";
    }

    private string NotJudgeChoice(string Player1, string Player2)
    {
        if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == true)
        {
            //２pが選択した
            Debug.Log("2がNotjudgedChoiceを通った");
            //judgePlayer = 2;
            return Player1;
        }
        else if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == false)
        {
            //１pが選択出来なかった
            Debug.Log("1がNotjudgedChoiceを通った");
            //judgePlayer = 1;
            return Player2;
        }
        else return "通ってない２";
    }
    #endregion

    private void ScenarioAction()
    {
        string[] msgs = _loadTextData[_nowTextLine].Split(',');
        if (msgs[0].Equals("#name"))
        {
            _name.text = msgs[1];
        }
        else if (msgs[0].Equals("#message"))
        {
            _isMessageDisp = true;
            _message.text = msgs[1];
            _isMessageDisp = false;
            if (msgs.Length >= 3)
            {
                _message.text = msgs[2];
            }
        }
        else if (msgs[0].Equals("#keywait"))
        {
            TextMove();
            _isWait = true;
        }
        else if (msgs[0].Equals("#BGMStart"))
        {
            // SoundManager.Instance.
        }
        else if (msgs[0].Equals("#BGMStop"))
        {
            // SoundManager.Instance.
        }
        else if (msgs[0].Equals("#Voicenum"))
        {
            SoundManager.Instance.SinarioSounds(0, 1);
            // SoundManager.Instantiate.
        }
        else if (msgs[0].Equals("#Karenface"))
        {
            //顔を変える(種類)
            if (int.Parse(msgs[1]) > -1 && int.Parse(msgs[1]) < FaceList.Count)
            {

                Karen.sprite = FaceList[int.Parse(msgs[1])];
                Karen1.SetActive(true);
            }
            else if (int.Parse(msgs[1]) == -1)
            {
                Karen1.SetActive(false);
                Karen.sprite = null;
            }
            else Debug.LogError(msgs[0] + " " + msgs[1] + "処理できません");
        }
        else if (msgs[0].Equals("#1pface"))
        {
            if (int.Parse(msgs[1]) > -1 && int.Parse(msgs[1]) < PlayerList.Count)
            {
                Player.sprite = PlayerList[int.Parse(msgs[1])];
                Player3.SetActive(true);
            }
            else if (int.Parse(msgs[1]) == -1)
            {
                Player3.SetActive(false);
                Player.sprite = null;
            }
            else Debug.LogError(msgs[0] + " " + msgs[1] + "処理できません");
        }

        else if (msgs[0].Equals("#2pface"))
        {
            if (int.Parse(msgs[1]) > -1 && int.Parse(msgs[1]) < PlayerList2.Count)
            {
                Player2.sprite = PlayerList2[int.Parse(msgs[1])];
                Player4.SetActive(true);
            }
            else if (int.Parse(msgs[1]) == -1)
            {
                Player4.SetActive(false);
                Player2.sprite = null;
            }
        }
        else if (_isSelectMessege)
            return;
        else if (msgs[0].Equals("#sentaku"))
            Choice2Word(msgs);
        //    //#sentaku,1#sentaku,2#sentaku,3
        //    会話文を変える
        //}
        else if (msgs[0].Equals("#kyoutu"))
        {
            //#sentaku,1#sentaku,2#sentaku,3
            //いずれかが終わったら共通の会話文にする
        }
        else if (msgs[0].Equals("#end"))
        {
            _isLoadEnd = false;
        }
        else if (msgs[0].Equals("//"))
            return;
        else
        {
            Debug.LogError(msgs[0] + "コマンドがないです");
        }
        _nowTextLine++;
    }

    private void Choice2Word(string[] msgs)
    {
        //メッセージ表示
        var selMsgs = msgs.Where(x => x.IndexOf("#") < 0).ToArray();
        _choiceControl.SetSelectMessage(selMsgs, SelectCallback);

        _isSelectMessege = true;
    }
    private void SelectCallback(int selectNum)
    {
        _isSelectMessege = false;
        msgs2[0] = "#end";
    }
    /// <summary>
    /// 選択を判定する
    /// </summary>
    
    private void LoadFile(string filename)
    {

        using (var str = new StreamReader(filename, System.Text.Encoding.UTF8))
        {
            var msg = "";
            while ((msg = str.ReadLine()) != null)
            {
                _loadTextData.Add(msg);
            }
        }
        _isLoadEnd = true;
    }

    //一文字ずつ表示
    #region
    IEnumerator TextDispCoroutine()
    {
        while (_stringCount < _message.text.Length)
        {
            _timer += Time.deltaTime;
            if (_timer >= _dispSpeed)
            {
                _timer = 0;
                _stringCount++;
                _text.text = _message.text.Substring(0, _stringCount);
            }
            yield return null;
        }
    }
    #endregion
}
