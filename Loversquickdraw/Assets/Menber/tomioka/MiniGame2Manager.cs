using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2Manager : MonoBehaviour
{
    //問題の答えが入るテキスト(保健室、図書館、教室)
    [SerializeField]
    private Text Place;

    private string Karen;
    private int Dankai = 1;

    private int Select1P;
    private int Select2P;

    [SerializeField]
    private PlayerCursorController playerCursorController;

    [SerializeField]
    private Image BackGround;

    //1図書館・2保健室・3教室
    [SerializeField]
    private List<Image> PlaceList = new List<Image>();

    [SerializeField]
    private List<GameObject> buttonMenuList = new List<GameObject>();

    //ミスした時の秒数　今後実装
    //private float TimeCount = 2;

    #region
    [SerializeField]
    private Button button1_1;
    [SerializeField]
    private Button button1_2;
    [SerializeField]
    private Button button1_3;
    [SerializeField]
    private Button button1_4;
    [SerializeField]
    private Button button1_5;
    [SerializeField]
    private Button button2_1;
    [SerializeField]
    private Button button2_2;
    [SerializeField]
    private Button button2_3;
    [SerializeField]
    private Button button2_4;
    [SerializeField]
    private Button button2_5;
    [SerializeField]
    private Button button3_1;
    [SerializeField]
    private Button button3_2;
    [SerializeField]
    private Button button3_3;
    [SerializeField]
    private Button button3_4;
    [SerializeField]
    private Button button3_5;
    [SerializeField]
    private Button button4_1;
    [SerializeField]
    private Button button4_2;
    [SerializeField]
    private Button button4_3;
    [SerializeField]
    private Button button4_4;
    [SerializeField]
    private Button button4_5;
    [SerializeField]
    private Button button5_1;
    [SerializeField]
    private Button button5_2;
    [SerializeField]
    private Button button5_3;
    [SerializeField]
    private Button button5_4;
    [SerializeField]
    private Button button5_5;
    [SerializeField]
    private Button button6_1;
    [SerializeField]
    private Button button6_2;
    [SerializeField]
    private Button button6_3;
    [SerializeField]
    private Button button6_4;
    [SerializeField]
    private Button button6_5;
    [SerializeField]
    private Button button7_1;
    [SerializeField]
    private Button button7_2;
    [SerializeField]
    private Button button7_3;
    [SerializeField]
    private Button button7_4;
    [SerializeField]
    private Button button7_5;
    [SerializeField]
    private Button button8_1;
    [SerializeField]
    private Button button8_2;
    [SerializeField]
    private Button button8_3;
    [SerializeField]
    private Button button8_4;
    [SerializeField]
    private Button button8_5;
    [SerializeField]
    private Button button9_1;
    [SerializeField]
    private Button button9_2;
    [SerializeField]
    private Button button9_3;
    [SerializeField]
    private Button button9_4;
    [SerializeField]
    private Button button9_5;
    [SerializeField]
    private Button button10_1;
    [SerializeField]
    private Button button10_2;
    [SerializeField]
    private Button button10_3;
    [SerializeField]
    private Button button10_4;
    [SerializeField]
    private Button button10_5;
    [SerializeField]
    private Button button11_1;
    [SerializeField]
    private Button button11_2;
    [SerializeField]
    private Button button11_3;
    [SerializeField]
    private Button button11_4;
    [SerializeField]
    private Button button11_5;
    [SerializeField]
    private Button button12_1;
    [SerializeField]
    private Button button12_2;
    [SerializeField]
    private Button button12_3;
    [SerializeField]
    private Button button12_4;
    [SerializeField]
    private Button button12_5;
    [SerializeField]
    private Button button13_1;
    [SerializeField]
    private Button button13_2;
    [SerializeField]
    private Button button13_3;
    [SerializeField]
    private Button button13_4;
    [SerializeField]
    private Button button13_5;
    [SerializeField]
    private Button button14_1;
    [SerializeField]
    private Button button14_2;
    [SerializeField]
    private Button button14_3;
    [SerializeField]
    private Button button14_4;
    [SerializeField]
    private Button button14_5;
    [SerializeField]
    private Button button15_1;
    [SerializeField]
    private Button button15_2;
    [SerializeField]
    private Button button15_3;
    [SerializeField]
    private Button button15_4;
    [SerializeField]
    private Button button15_5;

    #endregion



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
        Place.GetComponent<Text>();
        Place.text = Karen;
    }

    public void OnSelect1P()
    {
        Debug.Log("OnSelect1Pを通った");
        switch (Dankai)
        {
            case 1:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button1_1.Select();
                        break;
                    case 1:
                        button1_2.Select();
                        break;
                    case 2:
                        button1_3.Select();
                        break;
                    case 3:
                        button1_4.Select();
                        break;
                    case 4:
                        button1_5.Select();
                        break;
                }
                break;

            case 2:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button2_1.Select();
                        break;
                    case 1:
                        button2_2.Select();
                        break;
                    case 2:
                        button2_3.Select();
                        break;
                    case 3:
                        button2_4.Select();
                        break;
                    case 4:
                        button2_5.Select();
                        break;
                }
                break;

            case 3:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button3_1.Select();
                        break;
                    case 1:
                        button3_2.Select();
                        break;
                    case 2:
                        button3_3.Select();
                        break;
                    case 3:
                        button3_4.Select();
                        break;
                    case 4:
                        button3_5.Select();
                        break;
                }
                break;

            case 4:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button4_1.Select();
                        break;
                    case 1:
                        button4_2.Select();
                        break;
                    case 2:
                        button4_3.Select();
                        break;
                    case 3:
                        button4_4.Select();
                        break;
                    case 4:
                        button4_5.Select();
                        break;
                }
                break;

            case 5:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button5_1.Select();
                        break;
                    case 1:
                        button5_2.Select();
                        break;
                    case 2:
                        button5_3.Select();
                        break;
                    case 3:
                        button5_4.Select();
                        break;
                    case 4:
                        button5_5.Select();
                        break;
                }
                break;

            case 6:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button6_1.Select();
                        break;
                    case 1:
                        button6_2.Select();
                        break;
                    case 2:
                        button6_3.Select();
                        break;
                    case 3:
                        button6_4.Select();
                        break;
                    case 4:
                        button6_5.Select();
                        break;
                }
                break;

            case 7:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button7_1.Select();
                        break;
                    case 1:
                        button7_2.Select();
                        break;
                    case 2:
                        button7_3.Select();
                        break;
                    case 3:
                        button7_4.Select();
                        break;
                    case 4:
                        button7_5.Select();
                        break;
                }
                break;

            case 8:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button8_1.Select();
                        break;
                    case 1:
                        button8_2.Select();
                        break;
                    case 2:
                        button8_3.Select();
                        break;
                    case 3:
                        button8_4.Select();
                        break;
                    case 4:
                        button8_5.Select();
                        break;
                }
                break;

            case 9:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button9_1.Select();
                        break;
                    case 1:
                        button9_2.Select();
                        break;
                    case 2:
                        button9_3.Select();
                        break;
                    case 3:
                        button9_4.Select();
                        break;
                    case 4:
                        button9_5.Select();
                        break;
                }
                break;

            case 10:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button10_1.Select();
                        break;
                    case 1:
                        button10_2.Select();
                        break;
                    case 2:
                        button10_3.Select();
                        break;
                    case 3:
                        button10_4.Select();
                        break;
                    case 4:
                        button10_5.Select();
                        break;
                }
                break;

            case 11:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button11_1.Select();
                        break;
                    case 1:
                        button11_2.Select();
                        break;
                    case 2:
                        button11_3.Select();
                        break;
                    case 3:
                        button11_4.Select();
                        break;
                    case 4:
                        button11_5.Select();
                        break;
                }
                break;

            case 12:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button12_1.Select();
                        break;
                    case 1:
                        button12_2.Select();
                        break;
                    case 2:
                        button12_3.Select();
                        break;
                    case 3:
                        button12_4.Select();
                        break;
                    case 4:
                        button12_5.Select();
                        break;
                }
                break;

            case 13:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button13_1.Select();
                        break;
                    case 1:
                        button13_2.Select();
                        break;
                    case 2:
                        button13_3.Select();
                        break;
                    case 3:
                        button13_4.Select();
                        break;
                    case 4:
                        button13_5.Select();
                        break;
                }
                break;

            case 14:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button14_1.Select();
                        break;
                    case 1:
                        button14_2.Select();
                        break;
                    case 2:
                        button14_3.Select();
                        break;
                    case 3:
                        button14_4.Select();
                        break;
                    case 4:
                        button14_5.Select();
                        break;
                }
                break;

            case 15:
                switch (playerCursorController.RightMenu)
                {
                    case 0:
                        button15_1.Select();
                        break;
                    case 1:
                        button15_2.Select();
                        break;
                    case 2:
                        button15_3.Select();
                        break;
                    case 3:
                        button15_4.Select();
                        break;
                    case 4:
                        button15_5.Select();
                        break;
                }
                break;
        }
    }

    public void OnSelect2P()
    {
        Debug.Log("OnSelect2Pを通った");
        switch (Dankai)
        {
            case 1:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button1_1.Select();
                        break;
                    case 1:
                        button1_2.Select();
                        break;
                    case 2:
                        button1_3.Select();
                        break;
                    case 3:
                        button1_4.Select();
                        break;
                    case 4:
                        button1_5.Select();
                        break;
                }
                break;

            case 2:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button2_1.Select();
                        break;
                    case 1:
                        button2_2.Select();
                        break;
                    case 2:
                        button2_3.Select();
                        break;
                    case 3:
                        button2_4.Select();
                        break;
                    case 4:
                        button2_5.Select();
                        break;
                }
                break;

            case 3:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button3_1.Select();
                        break;
                    case 1:
                        button3_2.Select();
                        break;
                    case 2:
                        button3_3.Select();
                        break;
                    case 3:
                        button3_4.Select();
                        break;
                    case 4:
                        button3_5.Select();
                        break;
                }
                break;

            case 4:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button4_1.Select();
                        break;
                    case 1:
                        button4_2.Select();
                        break;
                    case 2:
                        button4_3.Select();
                        break;
                    case 3:
                        button4_4.Select();
                        break;
                    case 4:
                        button4_5.Select();
                        break;
                }
                break;

            case 5:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button5_1.Select();
                        break;
                    case 1:
                        button5_2.Select();
                        break;
                    case 2:
                        button5_3.Select();
                        break;
                    case 3:
                        button5_4.Select();
                        break;
                    case 4:
                        button5_5.Select();
                        break;
                }
                break;

            case 6:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button6_1.Select();
                        break;
                    case 1:
                        button6_2.Select();
                        break;
                    case 2:
                        button6_3.Select();
                        break;
                    case 3:
                        button6_4.Select();
                        break;
                    case 4:
                        button6_5.Select();
                        break;
                }
                break;

            case 7:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button7_1.Select();
                        break;
                    case 1:
                        button7_2.Select();
                        break;
                    case 2:
                        button7_3.Select();
                        break;
                    case 3:
                        button7_4.Select();
                        break;
                    case 4:
                        button7_5.Select();
                        break;
                }
                break;

            case 8:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button8_1.Select();
                        break;
                    case 1:
                        button8_2.Select();
                        break;
                    case 2:
                        button8_3.Select();
                        break;
                    case 3:
                        button8_4.Select();
                        break;
                    case 4:
                        button8_5.Select();
                        break;
                }
                break;

            case 9:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button9_1.Select();
                        break;
                    case 1:
                        button9_2.Select();
                        break;
                    case 2:
                        button9_3.Select();
                        break;
                    case 3:
                        button9_4.Select();
                        break;
                    case 4:
                        button9_5.Select();
                        break;
                }
                break;

            case 10:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button10_1.Select();
                        break;
                    case 1:
                        button10_2.Select();
                        break;
                    case 2:
                        button10_3.Select();
                        break;
                    case 3:
                        button10_4.Select();
                        break;
                    case 4:
                        button10_5.Select();
                        break;
                }
                break;

            case 11:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button11_1.Select();
                        break;
                    case 1:
                        button11_2.Select();
                        break;
                    case 2:
                        button11_3.Select();
                        break;
                    case 3:
                        button11_4.Select();
                        break;
                    case 4:
                        button11_5.Select();
                        break;
                }
                break;

            case 12:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button12_1.Select();
                        break;
                    case 1:
                        button12_2.Select();
                        break;
                    case 2:
                        button12_3.Select();
                        break;
                    case 3:
                        button12_4.Select();
                        break;
                    case 4:
                        button12_5.Select();
                        break;
                }
                break;

            case 13:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button13_1.Select();
                        break;
                    case 1:
                        button13_2.Select();
                        break;
                    case 2:
                        button13_3.Select();
                        break;
                    case 3:
                        button13_4.Select();
                        break;
                    case 4:
                        button13_5.Select();
                        break;
                }
                break;

            case 14:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button14_1.Select();
                        break;
                    case 1:
                        button14_2.Select();
                        break;
                    case 2:
                        button14_3.Select();
                        break;
                    case 3:
                        button14_4.Select();
                        break;
                    case 4:
                        button14_5.Select();
                        break;
                }
                break;

            case 15:
                switch (playerCursorController.LeftMenu)
                {
                    case 0:
                        button15_1.Select();
                        break;
                    case 1:
                        button15_2.Select();
                        break;
                    case 2:
                        button15_3.Select();
                        break;
                    case 3:
                        button15_4.Select();
                        break;
                    case 4:
                        button15_5.Select();
                        break;
                }
                break;
        }
    }



    public void ClickTrue()
    {
        Debug.Log("押すまで来た");


        switch (Dankai)
        {
            case 1:
                Debug.Log("1回目");
                Karen += "と";
                Destroy(buttonMenuList[0]);
                break;

            case 2:
                Debug.Log("2回目");
                Karen += "し";
                Destroy(buttonMenuList[1]);
                break;

            case 3:
                Debug.Log("3回目");
                Karen += "ょ";
                Destroy(buttonMenuList[2]);
                break;

            case 4:
                Debug.Log("4回目");
                Karen += "か";
                Destroy(buttonMenuList[3]);
                break;

            case 5:
                Debug.Log("5回目");
                Karen += "ん";
                Destroy(buttonMenuList[4]);

                //一度クリアにする関数
                Destroy(PlaceList[0]);

                Destroy(buttonMenuList[1]);
                ResetText();
                //BackGround.sprite = PlaceList[0];
                break;

            case 6:
                Debug.Log("6回目");
                Karen += "き";
                Destroy(buttonMenuList[5]);
                break;

            case 7:
                Debug.Log("7回目");
                Karen += "ょ";
                Destroy(buttonMenuList[6]);
                break;

            case 8:
                Debug.Log("8回目");
                Karen += "う";
                Destroy(buttonMenuList[7]);
                break;

            case 9:
                Debug.Log("9回目");
                Karen += "し";
                Destroy(buttonMenuList[8]);
                break;

            case 10:
                Debug.Log("10回目");
                Karen += "つ";
                Destroy(buttonMenuList[9]);
                //一度クリアにする関数
                Destroy(PlaceList[1]);
                ResetText();
                break;

            case 11:
                Debug.Log("11回目");
                Karen += "き";
                Destroy(buttonMenuList[10]);
                break;

            case 12:
                Debug.Log("12回目");
                Karen += "ょ";
                Destroy(buttonMenuList[11]);
                break;

            case 13:
                Debug.Log("13回目");
                Karen += "う";
                Destroy(buttonMenuList[12]);
                break;

            case 14:
                Debug.Log("14回目");
                Karen += "し";
                Destroy(buttonMenuList[13]);
                break;

            case 15:
                Debug.Log("15回目");
                Karen += "つ";
                Destroy(buttonMenuList[14]);
                Destroy(PlaceList[2]);
                //BackGround.sprite = PlaceList[2];
                Destroy(Place);
                break;
        }
        ChangeText();
        Dankai++;
    }

    public void Clickfalse()
    {
        //音鳴らす
    }

    private void ResetText()
    {
        Debug.Log("リセット");
        Karen = "";
        Debug.Log(Karen);
        ChangeText();
    }

}
