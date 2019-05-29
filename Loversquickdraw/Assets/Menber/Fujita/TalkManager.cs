using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{

    int Talktext = 0; //縦
    new int name = 0; //横
    public float fo; //点滅用
    private float fade = 0.035f;
    
    public GameObject NameTextmanager;
    public GameObject CommentTextmanager;
    public GameObject Sakura;
    //private Image sakuraImage;


    public void Start()
    {
        fo = Sakura.GetComponent<Image>().color.a;
    }

    //コメントと話すキャラの名前の配列(会話文は25個)
    string[][] Talk = new string[][]
    {
        //画面表示18文字を2行まで(全32文字)
        new string[]{ "俺は［１　Ｐ］。\n色濃（いろこい）高校の新入生だ。", "プレイヤー１"},
        new string[]{ "高校――すなわち青春。華々しい\n“高校生”の期間、俺は…", "プレイヤー１"},
        new string[]{ "「彼女」と過ごしたいッッッ！！", "プレイヤー１"},
        new string[]{ "というのも、俺には長い間淡い恋情を抱き続けてきた相手がいるのだ。", "プレイヤー１"},
        new string[]{ "その相手は……『夢宮華恋』\n（ゆめみや　かれん）。", "プレイヤー１"},
        new string[]{ "才色兼備、容姿端麗加えて世話焼き…。\nそんな彼女だが、俺の幼馴染だ。","プレイヤー１"},
        new string[]{ "正直、高嶺の花かと思わなくもないが、\n覚悟は決まっている。俺は彼女が好――", "プレイヤー１"},
        new string[]{ "いや、俺の方が好きなんだが？？", "プレイヤー２"},
        new string[]{ "――は？いや、誰？", "プレイヤー１"},
        new string[]{ "俺は［２　Ｐ］。\n色濃（いろこい）高校の新入生だ。", "プレイヤー２"},

        new string[]{ "高校――すなわち青春。華々しい\n“高校生”の期間、俺は…", "プレイヤー２"},
        new string[]{ "お前もそれやるんかァ！？\nつーか［２　Ｐ］かよ、何のつもりだ？", "プレイヤー１"},
        new string[]{"そう、忌々しいことに、華恋の幼馴染は俺だけではない。","プレイヤー１"},
        new string[]{ "この［２　Ｐ］と３人ですくすく育ってきた仲良し３人組なのだーー！", "プレイヤー１"},
        new string[]{"同じこと考えてるクセによく言うぜ。","プレイヤー２"},
        new string[]{"この道を通るってことは、だろ？","プレイヤー１"},
        new string[]{"！！","プレイヤー１"},
        new string[]{"華恋はこの先の角を左に曲がった通りを必ず通って登校する…。","プレイヤー１"},
        new string[]{"つまり、俺がこの道を通る理由は１つ！","プレイヤー１"},
        new string[]{"この先の曲がり角で\n華恋とぶつかることだーーッ！！","両プレイヤー"},

        new string[]{"この先はもう仲良し３人組ではない。華恋を巡る恋のライバル…！！！","プレイヤー１"},
        new string[]{"お前なんかに渡さない。夢宮華恋とイチャイチャするのはーー","両プレイヤー"},
        new string[]{"この俺だァァアアァァァッッ！！！！","両プレイヤー"},
        new string[]{"あいつと同時に駆け出す俺、\n目の前には十字路が迫っている。","両プレイヤー"},
        new string[]{"あいつよりも前に出て華恋とぶつかる。\nそのために俺はーー！！","両プレイヤー"},
        //画面表示文字は今は仮で２行まで(全32文字)
        new string[]{"１６文字目で改行させるあいうえお\n↑で１６字", "夢宮 華恋"},
        new string[]{"こんにちは","Player1"},
        new string[]{"こんばんは","Player2"},
    };

    //左クリックしたとき名前とコメントの表示、Debug.logは配列番号とそれに対して画面表示する文字を確認
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //前回の点滅の処理を止める
            for (int i = 0; i < 25; i++)
            {
                StopCoroutine("SakuraOut");
            }
            //今は仮で会話数(25個)をループさせてる
            if (Talktext == 25)
            {
                Talktext = 0;
            }

            Text Nametext = NameTextmanager.GetComponent<Text>();
            Text Commenttext = CommentTextmanager.GetComponent<Text>();
            name = 1;
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
            Nametext.text = Talk[Talktext][name];
            name = 0;
            Commenttext.text = Talk[Talktext][name];
            Debug.Log("Talk[" + Talktext + "][" + name + "]=" + Talk[Talktext][name]);
            
            //とりあえず配列３つを仮で作ったから３回ループでリセット
            if (Talktext == 25)
            if (Talktext == 3)
            //テキストが出終わったら点滅開始
            for (int i = 0; i < 25; i++)
            {
                StartCoroutine("SakuraOut");
            }
            Talktext++;
        }
    }

    //透明度を1~0と0~1へと徐々に変更することにより点滅させる(fadein,fadeoutの要領)
    IEnumerator SakuraOut()
    {
        while (true)
        {
            //fadein
            while (fo <= 1)
            {
                Sakura.GetComponent<Image>().color += new Color(0, 0, 0, fade);
                fo += fade;
                yield return null;
            }
            //fadeout
            while (fo >= 0)
            {
                Sakura.GetComponent<Image>().color -= new Color(0, 0, 0, fade);
                fo -= fade;
                yield return null;
            }
        }
    }
}
