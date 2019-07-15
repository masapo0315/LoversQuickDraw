using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Cursor;
    [SerializeField] private GameObject MenuWindow;

    //配列の数もメニューの総数を入れる
    [SerializeField] private GameObject[] menuNum = new GameObject[6];
    //同じく配列の数はメニューの総数を入れる
    private Vector3[] tmp = new Vector3[6];

    //メニューの総数を入れる
    private int MaxMenuNumber = 6;
    private int MenuNumber = 0;
    private bool MenuOn = false;

    void Start()
    {
        MenuOffCommand();
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = menuNum[i].transform.position;
            //Debug.Log(tmp[i]);
        }
    }


    void Update()
    {
        SceneCommand();
        MenuSelect();
        PushMenu();

        //コマンドを入れるとメニューが開く
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Can’t escape from my life 逃げ出せずに　輝く光を探して迷いながら戸惑いながら変わらない朝を壊して真夜中のrhythm止められない鼓動溺れるまま朝まで踊るよ何もかも捨てて消えていく想いは偽りの顔を覗かせて            怯えてた昨日踊り続ける今も見えない何かを求めてる苛立ち隠せず不機嫌な顔を一体誰に見せるの？ 教えて不条理なモラルに縛られたままもがき続けても意味の無い時間だけただ過ぎて行く何も変わらずにいつも描いてた憧れは遠いだけリセットしたい過去も捨てきれず求めてる理想襲いかかる現実苦悩の夜はまだ続く夜の光が照らしていく全てを嘲笑うように手のひらで転がされてるだけ誰も気付かずにいつか見た夢の中で羽ばたきはじめた翼は暗闇をさまよいながらどこかの逃げ道探してI can’t stop love’n you 押さえきれない溢れ出すこの想いを重ねても叶わぬ夢変わらない朝がまた来る           遅すぎた出会い早すぎた別れを誰かのせいにしたくなるもしも願いがただ一つ叶うならお願いあの時に戻らせて月の光に導かれるように夜に堕ちて行く果てしなく続く No Goal Endless Gameきっと逃げられないあの日見た夢の中で羽ばたきはじめた翼はいつかきっとたどり着ける自分だけの場所探してCan’t escape from my life逃げ出せずに輝く光を探して迷いながら戸惑いながら変わらない朝を壊してあの日見た夢の中で羽ばたきはじめた翼はいつかきっとたどり着ける自分だけの場所探してDon’t escape from my life逃げ出せずに輝く光を求めて迷いながら戸惑いながら新しい朝を迎えるCan’t escape from my life逃げ出せずにDon’t escape from my life逃げ出さずにCan’t escape from my life逃げ出せずに");
            MenuOnCommand();
        }
    }

    private void MenuOnCommand()
    {
        MenuWindow.SetActive(true);
        MenuOn = true;
    }

    private void MenuOffCommand()
    {
        MenuWindow.SetActive(false);
        MenuOn = false;
    }

    private void SceneCommand()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MenuNumber++;
            MenuNumber %= MaxMenuNumber;
            //Debug.Log(MenuNumber);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (MenuNumber == 0)
            {
                MenuNumber = MaxMenuNumber - 1;
                //Debug.Log(MenuNumber);
            }
            else
            {
                MenuNumber--;
                MenuNumber %= MaxMenuNumber;
                //Debug.Log(MenuNumber);
            }
        }
    }


    private void MenuSelect()
    {
        //caseはMaxMenuNumber-1まで
        switch (MenuNumber)
        {
            case 0:
                Cursor.transform.position = tmp[0];
                break;

            case 1:
                Cursor.transform.position = tmp[1];
                break;

            case 2:
                Cursor.transform.position = tmp[2];
                break;

            case 3:
                Cursor.transform.position = tmp[3];
                break;

            case 4:
                Cursor.transform.position = tmp[4];
                break;
            case 5:
                Cursor.transform.position = tmp[5];
                break;
        }
    }

    private void PushMenu()
    {
        if (MenuOn == true && Input.GetKeyDown(KeyCode.Space))
        {
            //caseはMaxMenuNumber-1まで
            switch (MenuNumber)
            {
                case 0:
                    MenuOffCommand();
                    break;

                case 1:
                    SceneManager.LoadScene("Title");
                    break;

                case 2:
                    SceneManager.LoadScene("Scenario");
                    break;

                case 3:
                    SceneManager.LoadScene("Scenario2");
                    break;

                case 4:
                    SceneManager.LoadScene("MiniGame1");
                    break;
                case 5:
                    SceneManager.LoadScene("MiniGame2_test");
                    break;
            }
        }
    }
}
