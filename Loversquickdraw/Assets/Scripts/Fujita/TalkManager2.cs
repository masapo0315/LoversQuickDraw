using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager2 : MonoBehaviour
{

    private int Talktext = 0; //縦
    private new int name = 0; //横
    private float fadeInOut; //点滅用
    private bool choice = false;
    string[] TEXTTAG_LIST = { "勝利者", "［敗北者］", "択プレイヤー" };

    #region

    [SerializeField] private float fade;
    [SerializeField] private GameObject TextFrame;
    [SerializeField] private ChoiceManager2 choiceManager2;
    [SerializeField] private GameObject NameTextmanager;
    [SerializeField] private GameObject CommentTextmanager;
    [SerializeField] private GameObject Sakura;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject cursor2;

    private void Start()
    {
        //string x = "プレイヤー１";
        //x = x.Replace("プレイヤー１", "name1");
        fadeInOut = Sakura.GetComponent<Image>().color.a;
    }

    //コメントと話すキャラの名前の配列(会話文は25個)
    string[][] Text = new string[][]
    {
        //画面表示18文字を2行まで(全36文字)
        //１区切り１０行
        new string[]{ "全力で路地を駆け抜け、一歩また一歩と\n［敗北者］を引き離す。もらった。", "勝利者"},
        new string[]{ "同時に、角の向こうから華恋の気配。\nタイミングも完璧……！！", "勝利者"},
        new string[]{ "うわははははは遅刻遅刻ゥ～～！！！", "勝利者"},
        new string[]{ "え……？きゃああっ！？", "華恋"},
        new string[]{ "もちろん、直前にブレーキをかけて\nお互いをかばうことも忘れない。", "勝利者"},
        new string[]{ "う～ん、いたたた……", "華恋"},
        new string[]{ "ってて…。あれ、華恋じゃねえか？\n大丈夫か、立てるか？", "勝利者"},
        new string[]{ "すかさず立ち上がって華恋の手を取る。\nこの辺の気配りが人気の秘訣だ。", "勝利者"},
        new string[]{ "ん……ありがと\nまったく、急ぐにしても程々にね？", "華恋"},
        new string[]{ "土埃を払い、柔らかく微笑む華恋。\n思わず、心臓がどきんと跳ねる。", "勝利者"},

        new string[]{ "見る者全てを虜にするようなこの笑顔。\n俺はこの子が好きなのだ、と再認識する。", "勝利者"},
        new string[]{ "それにしても、登校初日に曲がり角で\nぶつかるなんて、まるで運命みたいね？", "華恋"},
        new string[]{ "お……おう、そうか？", "勝利者"},
        new string[]{ "ふふ、なーんて。ほら、早くしないと\n遅刻しちゃうよ？ほら、行きましょ", "華恋"},
        new string[]{ "うお、おい待てって！", "勝利者"},
        new string[]{ "華恋は今度は悪戯っぽく笑うと、\nなんと俺の手を引き緩やかに走り出す。", "勝利者"},
        new string[]{ "危うく俺の方がオチるところだった。\n本当に俺なんかが華恋をオトせるのか？", "勝利者"},
        new string[]{ "何にしても、一歩リードなのは\n間違いない。", "勝利者"},
        new string[]{ "［敗北者］に逆転なんて許さないよう、\n気を引き締めなければ！", "勝利者"},
        new string[]{ "放課後。俺は偶然を装い一緒に帰るため\n扉の陰から華恋を見守っていた。", "プレイヤー１"},

        new string[]{ "あれ？ここにもない……\nん～、どこいっちゃったんだろ……", "華恋"},
        new string[]{ "しかし、華恋はなかなか教室を出ない。\n何かを探しているような様子だ。", "プレイヤー１"},
        new string[]{ "掛けられたバッグには、彼女の\n好きなキャラのグッズが揺れている。", "プレイヤー１"},
        new string[]{ "声をかけるチャンスだ！\n教室には華恋だけ。つまり二人きりッ！", "プレイヤー１"},
        new string[]{ "あれ、華恋じゃないか。どうしたんだ、\nこんな遅くまで", "プレイヤー２"},
        new string[]{ "あれ、プレイヤー２くん？", "華恋"},
        new string[]{ "あいつ……ロッカーの中から……！！くそ、遅れてたまるか！", "プレイヤー１"},
        new string[]{ "あれ、二人揃ってどうしたんだよ？", "プレイヤー１"},
        new string[]{ "プレイヤー１くんも！\n……実はね、探し物をしてるの", "華恋"},
        new string[]{ "探し物？何かなくしたのか？", "プレイヤー１"},

        new string[]{ "そうなの。髪飾りなんだけど……。\n大事にしてたから、諦めきれなくて", "華恋"},
        new string[]{ "確かに、いつもしている髪飾りがない。\n何かの拍子で落としてしまったのだろう", "プレイヤー１"},
        new string[]{ "そうか……そういうことなら任せろ。\n俺も一緒に探すよ。", "プレイヤー２"},
        new string[]{ "え、ほんと！？悪いよう……", "華恋"},
        new string[]{ "でも、そういうことなら\n頼らせてもらっちゃおうかな？", "華恋"},
        new string[]{ "くそ、俺が言おうとしたことばかり…！\nしかし、これはチャンスでもある――", "プレイヤー１"},
        new string[]{ "髪飾りを見つければ、好感度急上昇\n間違いなし！！", "両プレイヤー"},
        new string[]{ "二人とも、ありがとうね。\nそれで、落とした髪飾りなんだけど……", "華恋"},
        new string[]{ "スーパールーパー、っていう\nキャラクターのものなの。", "華恋"},
        new string[]{ "……スーパールーパー？？？？？", "両プレイヤー"},

        new string[]{ "そう、スーパールーパー。知らない？", "華恋"},
        new string[]{ "……まるで聞いたことがない。\nしかし……。", "両プレイヤー"},
        //選択肢前までで42行

        //選択１の場合(43)
        new string[]{ "ほんと！？　嬉しいな、なかなか\n知ってる人いなくて悲しかったんだよー", "華恋"},
        new string[]{ "ほら、これ！買ったときの写真！\nかわいいでしょ～", "華恋"},
        new string[]{ "も～、択プレイヤーってば水くさいよ～", "華恋"},//変更が必要
        new string[]{ "知ってるならもっと\n早く言ってくれれば良いのに～", "華恋"},
        new string[]{ "……だ、だいぶお気に入りみたいだな。\nなら、なおさら見つけてやらないとな！", "択プレイヤー"},
        new string[]{ "うん……！　頼りにしてるよ、\n択プレイヤーくん！", "華恋"},
        new string[]{ "……「やっぱり知らない」とは\nとても言えなかった。", "択プレイヤー"},
        new string[]{ "とても良い反応……だったが、\n少し後ろめたいな。……後で調べよう。", "択プレイヤー"},

        //選択肢２の場合(51)
        new string[]{ "うーん、やっぱりそんな感じなのかな？\n友達もみんなそういう反応なの。","華恋"},
        new string[]{ "こんなにかわいいのにね？", "華恋"},
        new string[]{ "この写真のが落としたやつか？\nスーパールーパー、だったか","択プレイヤー"},
        new string[]{ "かわいい……かわいい……？\nかわいい……のか…………？？","択プレイヤー"},
        new string[]{ "うん、買った時に写真撮っておいたの！\nえへへ、やっぱりかわいい……","華恋"},
        new string[]{ "ともかく！一緒に探してくれるのは\n嬉しいな！頼りにしてるからね？","華恋"},
        new string[]{ "反応はまずまず、だろうか。\nしかし髪飾りを見つければ問題なしだ！","択プレイヤー"},

        //選択肢３の場合(58)
        new string[]{ "えっ","華恋"},
        new string[]{ "瞬間、空気が凍った。\nもし音楽が流れていたなら止まる勢いで","択プレイヤー"},
        new string[]{ "知らないの、スーパールーパー――？\n今売ってないのかな、そんなわけ……", "華恋"},
        new string[]{ "心なしか華恋の目から光が失われている\nような気さえする。コワイ！","択プレイヤー"},
        new string[]{ "そんな、スーパールーパー……", "華恋"},
        new string[]{ "それほどに人気のないキャラクター\nだというの……！？","華恋"},
        new string[]{ "しかもどうやらひどく動揺している。\n余程の地雷を踏んでしまったのか。","択プレイヤー"},
        new string[]{ "うそ、嘘だと言ってよ択プレイヤーくん！\nほらこれ！買ったときの写真！", "華恋"},//変更が必要
        new string[]{ "……いや、他で見たことはないなあ", "択プレイヤー"},
        new string[]{ "嘘だあーっ！\nスーパールーパー……","華恋"},
        new string[]{ "そ、そんなにお気に入りだったのか…。\n見つかると良いな！","択プレイヤー"},
        new string[]{ "うん……ありがと……", "華恋"},
        new string[]{ "理不尽な気もするが、言葉選びを\n間違えてしまったようだ。","択プレイヤー"},
        new string[]{ "何とかして髪飾りを見つけ、\n汚名を払拭するしかない！","華恋"},

        //1,2,3から続けて(ミニゲーム２前の共通シナリオ)72行
        new string[]{ "で、この写真のを探せば良いんだな？", "プレイヤー１"},
        new string[]{ "うん。でも、どこでなくしたかも\n覚えてなくって。今日なのは確かだけど","華恋"},
        new string[]{ "あちこち回ることになっちゃうかも。\nゴメンね。","華恋"},
        new string[]{ "なに、お安い御用さ。\n俺に任せとけって！","プレイヤー２"},
        new string[]{ "そう、「俺」に……！", "プレイヤー２"},
        new string[]{ "華恋の髪飾りを探し出すのは――", "両プレイヤー"},
        new string[]{ "この俺だ！！！！", "両プレイヤー"},
    };
    #endregion
    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {
        if (choice == true)
        {
            choiceManager2.PushButton();
            if (choiceManager2.getdestroyFlag())
            {
                choice = false;
            }
        }
        //debug();
        //Inputkey();
    }
    /*
    //キー入寮kｂ
    void Inputkey()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaa");
            if (!choice)
            {
                sakuraOut();
                LordMinigame();
                TextFrame.SetActive(true);

                //会話数42個まで回したら選択肢を出してテキストフレームを消す
                if (Talktext == 42)
                {
                    TextFrame.SetActive(false);
                    cursor.SetActive(true);
                    cursor2.SetActive(true);
                    choice = true;
                    choiceManager2.SetActive();
                    return;
                }

                if (Talktext == 50 || Talktext == 57 || Talktext == 71)
                {
                    Talktext = 71;
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
    }
    private void road()
    {
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
    */
    //debug
    #region
    //デバック
    //void Move()
    //{
    //    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (!choice)
    //        {
    //            sakuraOut();
    //            LordMinigame();
    //            TextFrame.SetActive(true);

    //            //会話数42個まで回したら選択肢を出してテキストフレームを消す
    //            if (Talktext == 41)
    //            {
    //                TextFrame.SetActive(false);
    //                choice = true;
    //                choiceManager2.SetActive();
    //            }

    //            if (Talktext == 50 || Talktext == 57 || Talktext == 71)
    //            {
    //                Talktext = 71;
    //            }

    //            Text Nametext = NameTextmanager.GetComponent<Text>();
    //            Text Commenttext = CommentTextmanager.GetComponent<Text>();
    //            name = 1;
    //            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);
    //            Nametext.text = ReplaceTag(Text[Talktext][name]);
    //            name = 0;
    //            Commenttext.text = ReplaceTag(Text[Talktext][name]);
    //            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Text[Talktext][name]);

    //            sakuraStart();
    //            Talktext++;
    //        }
    //    }
    //}
    #endregion //

    //桜の点滅
    private void sakuraStart()
    {
        //テキストが出終わったら点滅開始
        for (int i = 0; i < 78; i++)
        {
            StartCoroutine("SakuraOut");
        }
    }

    private void sakuraOut()
    {
        //前回の点滅の処理を止める
        for (int i = 0; i < 78; i++)
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


    #region
    //string ReplaceTag(string _text)
    //{
    //    string tmp = _text;
    //    int cnt = 0;

    //    foreach (string tag in TEXTTAG_LIST)
    //    {
    //        switch (cnt)
    //        {
    //            case 0:
    //                tmp = tmp.Replace(tag, Winner("プレイヤー１","プレイヤー２"));
    //                break;
    //            case 1:
    //                tmp = tmp.Replace(tag, Loser("プログラマー","プレイヤー２"));
    //                break;
    //        }
    //        cnt++;
    //    }
    //    return tmp;
    //}
    #endregion

    private string JudgedChoice(string Player1, string Player2)
    {
        if (choiceManager2.stopChoice == true && choiceManager2.firstsPlayer == true)
        {
            //１pが選択した
            Debug.Log("１がjudgedChoiceを通った");
            return Player1;
        }
        else if (choiceManager2.stopChoice == true && choiceManager2.firstsPlayer == false)
        {
            //２pが選択した
            Debug.Log("２がjudgedChoiceを通った");
            return Player2;
        }
        else return "通ってないよ";
    }
    /*
    private string Winner(string Player1, string Player2)
    {
        if (Singlton.Instance.WinFlag[0] == 1)
        {
            //1P勝利
            return Player1;
        }
        else if (Singlton.Instance.WinFlag[0] == 2)
        {
            //2P勝利
            return Player2;
        }
        else return "WinError";
    }

    private string Loser(string Player1, string Player2)
    {
        if (Singlton.Instance.WinFlag[0] == 1)
        {
            //2p敗者
            return Player2;
        }
        else if (Singlton.Instance.WinFlag[0] == 2)
        {
            //1P敗者
            return Player1;
        }
        else return "LoseError";
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
                    tmp = tmp.Replace(tag, Winner("プレイヤー１", "プレイヤー２"));
                    break;
                case 1:
                    tmp = tmp.Replace(tag, Loser("プレイヤー１", "プレイヤー２"));
                    break;
                case 2:
                    tmp = tmp.Replace(tag, JudgedChoice("プレイヤー１", "プレイヤー２"));
                    break;
            }
            cnt++;
        }
        return tmp;
    }
    */
    public void LordMinigame()
    {
        if (Talktext == 78)
        {
                SceneManager.LoadScene("MiniGame2_test");
        }
    }

    public void ChoiceRoot()
    {
        Debug.Log(choiceManager2.rootflag);
        switch (choiceManager2.rootflag)
        {
            case 1:
                Talktext = 42;
                Debug.Log(choiceManager2.rootflag);
                //road();
                break;
            case 2:
                Talktext = 50;
                //road();
                break;
            case 3:
                Talktext = 57;
                //road();
                break;
        }
    }
}
