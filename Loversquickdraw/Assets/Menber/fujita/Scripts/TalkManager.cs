using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class TalkManager : SingletonMonoBehaviour<TalkManager>
{
    public int Talktext = 0; //縦
    private new int name = 0; //横
    private float fadeInOut; //点滅用
    public bool choiceAfterText = true; //選択後のシナリオ遷移
    private bool choice = false;
    private int judgePlayer = 0;
    private int stringCount;

    [Header("テキスト関連")]
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _message;
    [SerializeField]
    private Text _message2;
    //[SerializeField]
    //private string ScenarioDataName;
    [SerializeField]
    private int SoundNum = 0;

    //選択関連
    [SerializeField]
    private ChoiceControl _choiceControl;
    private string[] msgs = { "#select", "1", "2", "3" };
    private bool _isSelectMessege = false;

    private List<string> _loadTextData = new List<string>();
    private int _nowTextLine = 0;
    private bool _isLoadEnd = false;
    public bool _isWait = false;
    // private bool _isMessageDisp = false;
    private bool _isCharacterText = false;

    [Header("一文字ずつ表示+速度")]
    //[SerializeField]
    //private Text _text;
    [SerializeField]
    private float _dispSpeed;
    private float _timer = 0;
    private int _stringCount = 0;

    [Header("debug")]
    [SerializeField] public bool _ScenarioSkip;

    //参照するものをインスペクター上に表示
    [SerializeField] private List<Sprite> FaceList = new List<Sprite>();
    [SerializeField] private List<Sprite> PlayerList = new List<Sprite>();
    [SerializeField] private List<Sprite> PlayerList2 = new List<Sprite>();

    [Header("1p2pとプレイヤーの表示")]
    [SerializeField] private GameObject Karen1; //最初のSetActive用
    [SerializeField] private GameObject Player3; //最初のSetActive用
    [SerializeField] private GameObject Player4; //最初のSetActive用
    [SerializeField] private Image Karen;
    [SerializeField] private Image Player;
    [SerializeField] private Image Player2;

    [Header("桜まとめ")]
    [SerializeField] private float fade;
    [SerializeField] private GameObject Sakura;
    [SerializeField] private Image _sakura;

    [Header("選択まとめ")]
    [SerializeField] private ChoiceManager ChoiceManager;
    [SerializeField] public GameObject TextFrame;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject cursor2;
    //選択または勝敗によってactiveNomberで変える
    private int activeNumber;
    public int ActiveNumber { set { activeNumber = value; } }
    private bool _kokuhakuconwait;
    float _waitTime;
    float _time;
    bool once;
    bool _timeWait;
    //名前置き換え
    string[] nameRepTbl = { "カズオ", "ユージ" };

    //Sceneまたはシナリオを読む
    public bool _isSeEnd=false;

    private void Awake()
    {
        _isSeEnd = false;
    }
    private void Start()
    {
        //デバッグ用で残る
        PlayerPrefs.SetString("ScenarioNum", "4");
        activeNumber = PlayerPrefs.GetInt("MiniGame2Data", 0);
        _nowTextLine = 0;
        _isLoadEnd = false;
        _isSeEnd = false;
        var _ScenarioNum = PlayerPrefs.GetString("ScenarioNum");
        LoadFile(Application.dataPath + "/Scenario/ScLov" + _ScenarioNum + ".txt");
        StartCoroutine("SakuraOut");

    }

    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {

        _waitTime += Time.deltaTime;
        
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    SceneManager.LoadScene("MiniGame2");
        //}
        //TextMove();
        if (_isLoadEnd)
        {
            //if (_isMessageDisp)
            //{
            //    if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.M))
            //    {
            //        _isMessageDisp = false;
            //    }
            //}

            if (!_isWait)
            {
                ScenarioAction();
            }
            else if (_timeWait)
            {
                if (_waitTime - _time >= 3)
                {
                    _timeWait = false;
                    _isWait = false;
                }
            }

            else if (_kokuhakuconwait)
            {
                if (OVRPosition.Instance._1PTrue && OVRPosition.Instance._2PTrue)
                {
                    OVRPosition.Instance._isPosition = false;
                    _isWait = false;
                    _kokuhakuconwait = false;
                }
                
                if (_waitTime-_time >= 6 && !once)
                {
                    once = true;
                    _message.text = "コントローラーを前に突き出してください。";
                    _message2.text = null;
                }
                
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.M))
            {
                StopCoroutine("SakuraOut");
                _isWait = false;
            }
        }
        

    }

    //private void TextMove()
    //{
    //    if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.M))
    //    {
    //        //_stringCount = 1;
    //        //_timer = 0;
    //        //_message.text = msgs[1].Substring(0, _stringCount);
    //        //TextDispCoroutine();
    //        if (!choice)
    //        {
    //            //TextFrame.SetActive(true);
    //        }
    //    }
    //}

    #region 桜の動き

    //透明度を1~0と0~1へと徐々に変更することにより点滅させる(fadein,fadeoutの要領)
    IEnumerator SakuraOut()
    {
        while (true)
        {
            //フェードイン
            while (Sakura.GetComponent<Image>().color.a < 1)
            {
                Sakura.GetComponent<Image>().color += new Color(0, 0, 0, fade);
                fadeInOut += fade;
                yield return null;
            }
            //フェードアウト
            while (Sakura.GetComponent<Image>().color.a > 0)
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
        msgs[0] = msgs[0].ToLower();
        Debug.LogWarning(msgs[0]);
        if (msgs[0].Equals("#kyoutu"))
        {
            _ScenarioSkip = false;
            Debug.Log(_ScenarioSkip);
            //#sentaku,1#sentaku,2#sentaku,3
            //いずれかが終わったら共通の会話文にする
        }
        else if (msgs[0].Equals("#coninit"))
        {
            OVRPosition.InitPosition();
        }
        else if (msgs[0].Equals("#concheck"))
        {
            _time = _waitTime;
            _isWait = true;
            OVRPosition.Instance._isPosition = true;
            _kokuhakuconwait = true;

        }
        else if (msgs[0].Equals("#convib"))
        {
            OVRControllerVib.ControllerVib(activeNumber);
        }
        else if (msgs[0].Equals("#timewait"))
        {
            _isWait = true;
            _time = _waitTime;
            _timeWait = true;
        }

        //背景変更用0,1,2アタッチしたら通学路、教室、屋上
        //
        else if (msgs[0].Equals("#bgsprite"))
        {
            SpriteManager.SpriteDisp(int.Parse(msgs[1]));
        }
        //画面全体に出すとき華恋が転んだ時など一枚絵
        else if (msgs[0].Equals("#spritechange"))
        {
            SpriteManager.SpriteSwitch(int.Parse(msgs[1]));
        }
        else if (_ScenarioSkip)
        {
            _nowTextLine++;
            return;
        }

        else if (msgs[0].Equals("#name"))
        {
            msgs[1] = msgs[1].Replace("プレイヤー１", nameRepTbl[0]);
            msgs[1] = msgs[1].Replace("プレイヤー２", nameRepTbl[1]);
            msgs[1] = msgs[1].Replace("択プレイヤー", nameRepTbl[activeNumber]);
            msgs[1] = msgs[1].Replace("非プレイヤー", nameRepTbl[1 - activeNumber]);
            msgs[1] = msgs[1].Replace("勝利者", nameRepTbl[activeNumber]);
            msgs[1] = msgs[1].Replace("敗北者", nameRepTbl[1 - activeNumber]);
            //FaceChange();
            _name.text = msgs[1];
        }
        else if (msgs[0].Equals("#message"))
        {
            msgs[1] = msgs[1].Replace("プレイヤー１", nameRepTbl[0]);
            msgs[1] = msgs[1].Replace("プレイヤー２", nameRepTbl[1]);
            msgs[1] = msgs[1].Replace("択プレイヤー", nameRepTbl[activeNumber]);
            msgs[1] = msgs[1].Replace("非プレイヤー", nameRepTbl[1 - activeNumber]);
            msgs[1] = msgs[1].Replace("勝利者", nameRepTbl[activeNumber]);
            msgs[1] = msgs[1].Replace("敗北者", nameRepTbl[1 - activeNumber]);
            if (msgs.Length > 2)
            {
                msgs[2] = msgs[2].Replace("プレイヤー１", nameRepTbl[0]);
                msgs[2] = msgs[2].Replace("プレイヤー２", nameRepTbl[1]);
                msgs[2] = msgs[2].Replace("択プレイヤー", nameRepTbl[activeNumber]);
                msgs[2] = msgs[2].Replace("非プレイヤー", nameRepTbl[1 - activeNumber]);
                msgs[2] = msgs[2].Replace("勝利者", nameRepTbl[activeNumber]);
                msgs[2] = msgs[2].Replace("敗北者", nameRepTbl[1 - activeNumber]);
            }

            if (msgs.Length == 2)
            {
                _message.text = msgs[1];
                _message2.text = null;
            }
            else if (msgs.Length == 3)
            {
                Debug.Log(msgs[1] + " " + msgs[2]);
                _message.text = msgs[1];
                _message2.text = msgs[2];
            }
        }

        #region ショートカット
        else if (msgs[0].Equals("#keywait"))
        {
            StartCoroutine("SakuraOut");
            //StopCoroutine("TextDispCoroutine");
            //TextMove();
            _isWait = true;
        }
        //else if (msgs[0].Equals("#lineplus"))
        //{
        //    _nowTextLine += 5;
        //}
        else if (msgs[0].Equals("#bgmstart"))
        {
            SoundManager.Instance.BGMFirstPlay();
        }
        else if (msgs[0].Equals("#bgmstop"))
        {
            SoundManager.BGMStop();
        }
        else if (msgs[0].Equals("#voicenum"))
        {
            SoundManager.Instance.SinarioSounds(SoundNum, 1);
            SoundNum++;
        }
        else if (msgs[0].Equals("#karenface"))
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
        #endregion
        else if (msgs[0].Equals("#1pface"))
        {
            if (int.Parse(msgs[1]) > -1 && int.Parse(msgs[1]) < PlayerList.Count || ChoiceManager.firstsPlayer == true)
            {
                Player.sprite = PlayerList[int.Parse(msgs[1])];
                Player3.SetActive(true);
            }
            else if (int.Parse(msgs[1]) == -1 || ChoiceManager.firstsPlayer == true)
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
        else if (msgs[0].Equals("#choiceface"))
        {
            Debug.Log("choicefaceを通った");
            if (int.Parse(msgs[1]) == -1)
            {
                Player3.SetActive(false);
                Player.sprite = null;
                Player4.SetActive(false);
                Player2.sprite = null;
            }
            else if (int.Parse(msgs[1]) == 0)
            {
                if (activeNumber == 0)
                {
                    Player.sprite = PlayerList[0];
                    Player3.SetActive(true);
                }
                else if (activeNumber == 1)
                {
                    Player2.sprite = PlayerList2[0];
                    Player4.SetActive(true);
                }
            }
        }
        else if (msgs[0].Equals("#nochoiceface"))
        {
            Debug.Log("nochoicefaceを通った");
            if (int.Parse(msgs[1]) == -1)
            {
                Player3.SetActive(false);
                Player.sprite = null;
                Player4.SetActive(false);
                Player2.sprite = null;
            }
            else if (int.Parse(msgs[1]) == 0)
            {
                if (activeNumber == 0)
                {
                    Player2.sprite = PlayerList2[0];
                    Player4.SetActive(true);
                }
                else if (activeNumber == 1)
                {
                    Player.sprite = PlayerList[0];
                    Player3.SetActive(true);
                }
            }
        }
        else if (_isSelectMessege)
            return;
        //会話文を1,2,3のいずれかに変える
        else if (msgs[0].Equals("#label"))
        {
            TextFrame.SetActive(false);
            Choice2Word(msgs);
            //if (int.Parse(msgs[1]) != ChoiceManager.rootflag)//一致してないときに
            // _ScenarioSkip = true;
        }
        else if (msgs[0].Equals("#sentaku"))
        {
            Debug.LogWarning(_ScenarioSkip);
            if (int.Parse(msgs[1]) != ChoiceManager.rootflag)//一致してないときに
                _ScenarioSkip = true;
            Debug.Log(msgs[0] + msgs[1]);
        }

        else if (msgs[0].Equals("#end"))
        {
            //PlayerPlrefsについて
            _isSeEnd = true;
            _isLoadEnd = false;
            return;
        }
        else if (msgs[0].Equals("//"))
        {
            Debug.Log("comment");
            _nowTextLine++;
            return;
        }
        else
        {
            Debug.LogError(msgs[0] + "コマンドがないです");
        }
        _nowTextLine++;
    }

    private void Choice2Word(string[] msgs)
    {
        //メッセージ表示
        var selMsgs = msgs.Where(x => x.IndexOf("#") < 0).ToArray();//"#"を除いた配列３つ
        _choiceControl.SetSelectMessage(selMsgs, SelectCallback);
        _isSelectMessege = true;
    }
    private void SelectCallback(int selectNum)
    {
        _isSelectMessege = false;
        Debug.Log("select Num = " + selectNum);
        _nowTextLine = SearchLabel(selectNum);
    }
    /// <summary>
    /// 選択肢の番号
    /// </summary>
    /// <param name="selectNum">選択した番号</param>
    /// <returns></returns>
    private int SearchLabel(int selectNum)
    {
        var nowLine = _nowTextLine-50;
        while (nowLine < _loadTextData.Count)
        {
            var msgs = _loadTextData[nowLine].Split(',');
            if (msgs[0].Equals("#sentaku"))
            {
                var num = int.Parse(msgs[1]);
                if (num == selectNum)
                    return nowLine + 1;
            }
            nowLine++;
        }
        return 0;
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
                //txtが空白ならその行をとばす
                if (string.IsNullOrEmpty(msg))
                    continue;
                _loadTextData.Add(msg);
            }
        }
        _isLoadEnd = true;
    }

    //一文字ずつ表示
    #region
    IEnumerator TextDispCoroutine()
    {
        while (_stringCount < msgs[1].Length)
        {
            _timer += Time.deltaTime;
            if (_timer >= _dispSpeed)
            {
                _timer = 0;
                _stringCount++;
                _message.text = msgs[1].Substring(0, _stringCount);
                Debug.Log(_stringCount);
            }
            yield return null;
        }
    }
    #endregion
}
