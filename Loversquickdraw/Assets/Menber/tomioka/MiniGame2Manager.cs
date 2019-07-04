using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject TalkKarenObject;

    //問題の答えが入るテキスト(保健室、図書館、教室)
    private Text basyo;

    private string Karen;
    private int Dankai = 1;

    private int Select1P;
    private int Select2P;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Image BackGround;

    //1図書館・2保健室・3教室
    [SerializeField]
    private List<Sprite> PlaceList = new List<Sprite>();

    [SerializeField]
    private List<GameObject> buttonMenuList = new List<GameObject>();

    //ミスした時の秒数
    private float TimeCount = 2;


    [SerializeField]
    private List<Button> button1List = new List<Button>();
    [SerializeField]
    private List<Button> button2List = new List<Button>();
    [SerializeField]
    private List<Button> button3List = new List<Button>();
    [SerializeField]
    private List<Button> button4List = new List<Button>();
    [SerializeField]
    private List<Button> button5List = new List<Button>();
    [SerializeField]
    private List<Button> button6List = new List<Button>();
    [SerializeField]
    private List<Button> button7List = new List<Button>();
    [SerializeField]
    private List<Button> button8List = new List<Button>();
    [SerializeField]
    private List<Button> button9List = new List<Button>();
    [SerializeField]
    private List<Button> button10List = new List<Button>();
    [SerializeField]
    private List<Button> button11List = new List<Button>();
    [SerializeField]
    private List<Button> button12List = new List<Button>();
    [SerializeField]
    private List<Button> button13List = new List<Button>();
    [SerializeField]
    private List<Button> button14List = new List<Button>();
    [SerializeField]
    private List<Button> button15List = new List<Button>();




    // Use this for initialization
    void Start()
    {
        BackGround.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeText()
    {
        basyo = TalkKarenObject.GetComponent<Text>();
        basyo.text = Karen;
    }

    public void ClickTrue()
    {
        Debug.Log("おすまで来た");

        switch (Dankai)
        {
            case 1:
                Debug.Log("とまで来た");
                Karen += "と";
                Destroy(buttonMenuList[0]);
                //buttonList.Remove(0);
                buttonMenuList[1].SetActive(true);
                break;

            case 2:
                Karen += "し";
                Destroy(buttonMenuList[1]);
                buttonMenuList[2].SetActive(true);
                break;

            case 3:
                Karen += "ょ";
                Destroy(buttonMenuList[2]);
                buttonMenuList[3].SetActive(true);
                break;

            case 4:
                Karen += "か";
                Destroy(buttonMenuList[3]);
                buttonMenuList[4].SetActive(true);
                break;

            case 5:
                Karen += "ん";
                Destroy(buttonMenuList[4]);
                buttonMenuList[5].SetActive(true);

                //一度クリアにする関数
                BackGround.sprite = PlaceList[0];
                Destroy(buttonMenuList[0]);

                Karen = "";
                break;

            case 6:
                Karen += "き";
                Destroy(buttonMenuList[5]);
                buttonMenuList[6].SetActive(true);
                break;

            case 7:
                Karen += "ょ";
                Destroy(buttonMenuList[6]);
                buttonMenuList[7].SetActive(true);
                break;

            case 8:
                Karen += "う";
                Destroy(buttonMenuList[7]);
                buttonMenuList[8].SetActive(true);
                break;

            case 9:
                Karen += "し";
                Destroy(buttonMenuList[8]);
                buttonMenuList[9].SetActive(true);
                break;

            case 10:
                Karen += "つ";
                Destroy(buttonMenuList[9]);
                buttonMenuList[10].SetActive(true);
                //一度クリアにする関数
                BackGround.sprite = PlaceList[1];

                Karen = "";
                break;

            case 11:
                Karen += "ほ";
                Destroy(buttonMenuList[10]);
                buttonMenuList[11].SetActive(true);
                break;

            case 12:
                Karen += "け";
                Destroy(buttonMenuList[11]);
                buttonMenuList[12].SetActive(true);
                break;

            case 13:
                Karen += "ん";
                Destroy(buttonMenuList[12]);
                buttonMenuList[13].SetActive(true);
                break;

            case 14:
                Karen += "し";
                Destroy(buttonMenuList[13]);
                buttonMenuList[14].SetActive(true);
                break;

            case 15:
                Karen += "つ";
                Destroy(buttonMenuList[14]);
                BackGround.sprite = PlaceList[2];
                break;
        }
        ChangeText();
        Dankai++;
    }

    public void Clickfalse()
    {
        if (TimeCount <= 0)
        {

        }
    }

    /*
    public void ClickPlayer1()
    {
        Select1P = playerController.RightMenu;
        switch (Dankai)
        {
            case 1:
                button1List[Select1P].Select();
                break;

            case 2:
                button2List[Select1P].Select();
                break;

            case 3:
                button3List[Select1P].Select();
                break;

            case 4:
                button4List[Select1P].Select();
                break;

            case 5:
                button5List[Select1P].Select();
                break;

            case 6:
                button6List[Select1P].Select();
                break;

            case 7:
                button7List[Select1P].Select();
                break;

            case 8:
                button8List[Select1P].Select();
                break;

            case 9:
                button9List[Select1P].Select();
                break;

            case 10:
                button10List[Select1P].Select();
                break;

            case 11:
                button11List[Select1P].Select();
                break;

            case 12:
                button12List[Select1P].Select();
                break;

            case 13:
                button13List[Select1P].Select();
                break;

            case 14:
                button14List[Select1P].Select();
                break;

            case 15:
                button15List[Select1P].Select();
                break;
        }
    }

    public void ClickPlayer2()
    {
        Select2P = playerController.LeftMenu;
        switch (Dankai)
        {
            case 1:
                button1List[Select2P].Select();
                break;

            case 2:
                button2List[Select2P].Select();
                break;

            case 3:
                button3List[Select2P].Select();
                break;

            case 4:
                button4List[Select2P].Select();
                break;

            case 5:
                button5List[Select2P].Select();
                break;

            case 6:
                button6List[Select2P].Select();
                break;

            case 7:
                button7List[Select2P].Select();
                break;

            case 8:
                button8List[Select2P].Select();
                break;

            case 9:
                button9List[Select2P].Select();
                break;

            case 10:
                button10List[Select2P].Select();
                break;

            case 11:
                button11List[Select2P].Select();
                break;

            case 12:
                button12List[Select2P].Select();
                break;

            case 13:
                button13List[Select2P].Select();
                break;

            case 14:
                button14List[Select2P].Select();
                break;

            case 15:
                button15List[Select2P].Select();
                break;
        }
    }
    */
}
