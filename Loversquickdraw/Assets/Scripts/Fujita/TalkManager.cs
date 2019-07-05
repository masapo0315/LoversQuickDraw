using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    private int Talktext = 0; //縦
    private new int name = 0; //横
    private float fadeInOut; //点滅用
    private float fade = 0.035f;
    public bool choiceAfterText = true;
    private bool choice = false;

    string[] TEXTTAG_LIST = { "択プレイヤー", "非選択Ｐ" };

    #region

    [SerializeField] private GameObject TextFrame;
    [SerializeField] private ChoiceManager ChoiceManager;
    [SerializeField] private GameObject NameTextmanager;
    [SerializeField] private GameObject CommentTextmanager;
    [SerializeField] private GameObject Sakura;

    
    private void Start()
    {
        //string x = "プレイヤー１";
        //x = x.Replace("プレイヤー１", "name1");
        fadeInOut = Sakura.GetComponent<Image>().color.a;
    }

    //コメントと話すキャラの名前の配列(会話文は25個)
    [SerializeField]
    private string[][] Text = new string[][]
    {
        //画面表示18文字を2行まで(全36文字)
        new string[]{ "俺は。プレイヤー１\n色濃（いろこい）高校の新入生だ。", "プレイヤー１"},
        new string[]{ "高校――すなわち青春。華々しい\n“高校生”の期間、俺は…", "プレイヤー１"},
        new string[]{ "「彼女」と過ごしたいッッッ！！", "プレイヤー１"},
        new string[]{ "というのも、俺には長い間淡い恋情を抱き続けてきた相手がいるのだ。", "プレイヤー１"},
        new string[]{ "その相手は……『夢宮華恋』\n（ゆめみや　かれん）。", "プレイヤー１"},
        new string[]{ "才色兼備、容姿端麗加えて世話焼き…。\nそんな彼女だが、俺の幼馴染だ。","プレイヤー１"},
        new string[]{ "正直、高嶺の花かと思わなくもないが、\n覚悟は決まっている。俺は彼女が好――", "プレイヤー１"},
        new string[]{ "いや、俺の方が好きなんだが？？", "プレイヤー２"},
        new string[]{ "――は？いや、誰？", "プレイヤー１"},
        new string[]{ "俺は。プレイヤー２。\n色濃（いろこい）高校の新入生だ。", "プレイヤー２"},

        new string[]{ "高校――すなわち青春。華々しい\n“高校生”の期間、俺は…", "プレイヤー２"},
        new string[]{ "お前もそれやるんかァ！？\nつーかプレイヤー２かよ、何のつもりだ？", "プレイヤー１"},
        new string[]{ "そう、忌々しいことに、華恋の幼馴染は俺だけではない。","プレイヤー１"},
        new string[]{ "このプレイヤー２と３人ですくすく育ってきた仲良し３人組なのだーー！", "プレイヤー１"},
        new string[]{ "同じこと考えてるクセによく言うぜ。","プレイヤー２"},
        new string[]{ "この道を通るってことは、だろ？","プレイヤー１"},
        new string[]{ "！！","プレイヤー１"},
        new string[]{ "華恋はこの先の角を左に曲がった通りを必ず通って登校する…。","プレイヤー１"},
        new string[]{ "つまり、俺がこの道を通る理由は１つ！","プレイヤー１"},
        new string[]{ "この先の曲がり角で\n華恋とぶつかることだーーッ！！","両プレイヤー"},

        new string[]{ "この先はもう仲良し３人組ではない。華恋を巡る恋のライバル…！！！","プレイヤー１"},
        new string[]{ "お前なんかに渡さない。夢宮華恋とイチャイチャするのはーー","両プレイヤー"},
        new string[]{ "この俺だァァアアァァァッッ！！！！","両プレイヤー"},
        new string[]{ "あいつと同時に駆け出す俺、\n目の前には十字路が迫っている。","両プレイヤー"},
        new string[]{ "あいつよりも前に出て華恋とぶつかる。\nそのために俺はーー！！","両プレイヤー"},
        //ここまでで25行

        //選択１の場合(26)
        new string[]{ "一歩先んじた俺は、十字路で急ブレーキ、\n迷いなくインド人を右に！","択プレイヤー"},
        new string[]{ "思惑通り、角の向こうには華恋の頭が\n見え――ない！？", "択プレイヤー"},
        new string[]{ "スピードを出しすぎた……！", "択プレイヤー"},
        new string[]{ "あれ、択プレイヤーくん！？もー、また\n危ないことして―！気を付けてね～！？", "華恋"},
        new string[]{ "しかし、遠目に目が合ったのは俺。\n何はともあれ一歩リードだ。やったぜ。", "択プレイヤー"},

        //選択２の場合(31)
        new string[]{ "一歩先んじた俺は、十字路で急ブレーキ、\n迷いなくインド人を右に！","択プレイヤー"},
        new string[]{ "遅れた非選択Ｐが遅れて曲がる！\nこれは勝ったも同然……！", "択プレイヤー"},
        new string[]{ "なあ、曲がり角逆じゃねえか！？", "非選択Ｐ"},
        new string[]{ "はあ！？", "択プレイヤー"},
        new string[]{ "走りながら、道順を思い出す――", "択プレイヤー"},
        new string[]{ "あ“あ”―――っ！！？", "択プレイヤー"},
        new string[]{ "確かにというか、既に目の前の道は\n住宅街の行き止まり！アブナイ！", "択プレイヤー"},
        new string[]{ "うおおおお南無三ッ！！", "択プレイヤー"},
        new string[]{ "今度こそ急ブレーキ、１８０゜ターン！\nしかしこれで勝負は振出しに戻る…！", "択プレイヤー"},
        
        //選択３の場合(40)
        new string[]{ "一歩先んじた俺は、急ブレーキを\nキャンセルして猛進！十字路を――","択プレイヤー"},
        new string[]{ "曲がり損ねたァァァ！！！", "択プレイヤー"},
        new string[]{ "ふはははバカめ！チキレンースやってる\n場合じゃないんだよ！！","非選択Ｐ"},
        new string[]{ "非選択Ｐは後ろの角に消えてゆく…！\n逆に出遅れてしまった！","択プレイヤー"},

        //選択肢後の共通シナリオ
        new string[]{ "くそ、最初の接触は失敗か！\n少女漫画も楽じゃねぇな！","プレイヤー１"},
        new string[]{ "こんなハナから汗臭い少女漫画が\nあるかよ!","プレイヤー２"},
    };
    #endregion
    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {
        if (choice == true)
        {
            ChoiceManager.PushButton();
            if (ChoiceManager.getdestroyFlag())
            {
                choice = false;
            }
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!choice)
            {
                sakuraOut();
                LordMinigame();
                TextFrame.SetActive(true);

                //今は仮で会話数(25個)をループさせてる
                if (Talktext == 25)
                {
                    TextFrame.SetActive(false);
                    choice = true;
                    ChoiceManager.SetActive();
                }

                if (Talktext == 30 || Talktext == 39 || Talktext == 43)
                {
                    Talktext = 43;
                }

                Text Nametext = NameTextmanager.GetComponent<Text>();
                Text Commenttext = CommentTextmanager.GetComponent<Text>();
                name = 1;
                Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);
                Nametext.text = ReplaceTag(Text[Talktext][name]);
                name = 0;
                Commenttext.text = ReplaceTag(Text[Talktext][name]);
                Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);

                sakuraStart();
                Talktext++;
            }
        }
        /*
        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!choice)
        //    {
        //        sakuraOut();
        //        LordMinigame();
        //        TextFrame.SetActive(true);

        //        //今は仮で会話数(25個)をループさせてる
        //        if (Talktext == 25)
        //        {
        //            TextFrame.SetActive(false);
        //            choice = true;
        //            ChoiceManager.SetActive();
        //        }

        //        if (Talktext == 30 || Talktext == 39 || Talktext == 43)
        //        {
        //            Talktext = 43;
        //        }

        //        Text Nametext = NameTextmanager.GetComponent<Text>();
        //        Text Commenttext = CommentTextmanager.GetComponent<Text>();
        //        name = 1;
        //        Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);
        //        Nametext.text = ReplaceTag(Text[Talktext][name]);
        //        name = 0;
        //        Commenttext.text = ReplaceTag(Text[Talktext][name]);
        //        Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);

        //        sakuraStart();
        //        Talktext++;
        //    }
        //}*/
    }

    //桜の点滅
    private void sakuraStart()
    {
        //テキストが出終わったら点滅開始
        for (int i = 0; i < 46; i++)
        {
            StartCoroutine("SakuraOut");
        }
    }

    private void sakuraOut()
    {
        //前回の点滅の処理を止める
        for (int i = 0; i < 46; i++)
        {
            StopCoroutine("SakuraOut");
        }
    }

    private string JudgeChoice(string Player1, string Player2)
    {
        Debug.Log(ChoiceManager.firstsPlayer);
        Debug.Log(ChoiceManager.stopChoice);
        if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == true)
        {
            //１pが選択した
            Debug.Log("１がjudgedChoiceを通った");
            return Player1;
        }
        else if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == false)
        {
            //２pが選択出来なかった
            Debug.Log("２がjudgedChoiceを通った");
            return Player2;
        }
        else return "";
    }

    private string NotJudgeChoice(string Player1, string Player2)
    {
        if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == true)
        {
            //２pが選択した
            Debug.Log("2がNotjudgedChoiceを通った");
            return Player1;
        }
        else if (ChoiceManager.stopChoice == true && ChoiceManager.firstsPlayer == false)
        {
            //１pが選択出来なかった
            Debug.Log("1がNotjudgedChoiceを通った");
            return Player2;
        }
        else return "";
    }

    string ReplaceTag(string _text)
    {
        string tmp = _text;
        int cnt = 0;

        foreach (string tag in TEXTTAG_LIST)
        {
            switch (cnt)
            {
                case 0:
                    tmp = tmp.Replace(tag, JudgeChoice("プレイヤー１","プレイヤー２"));
                    break;
                case 1:
                    tmp = tmp.Replace(tag, NotJudgeChoice("プレイヤー１", "プレイヤー２"));
                    break;
            }
            cnt++;
        }
        return tmp;
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

    public void LordMinigame()
    {
        if (Talktext == 45)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("MiniGame1");
            }
        }
    }

    public void ChoiceRoot()
    {
        Debug.Log("ここをとおった");
        Debug.Log(ChoiceManager.rootflag);
        switch (ChoiceManager.rootflag)
        {
            case 1:
                Talktext = 26;
                Debug.Log(ChoiceManager.rootflag);
                break;
            case 2:
                Talktext = 31;
                break;
            case 3:
                Talktext = 40;
                Debug.Log(ChoiceManager.rootflag);
                break;
            default:
                break;
        }
    }
}
