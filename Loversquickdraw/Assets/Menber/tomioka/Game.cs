using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject TalkKarenObject;

    private Text TalkKaren;

    private string Karen;

    private int Dankai = 0;


    [SerializeField]
    private GameObject Button1;
    [SerializeField]
    private GameObject Button2;
    [SerializeField]
    private GameObject Button3;
    [SerializeField]
    private GameObject Button4;
    [SerializeField]
    private GameObject Button5;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeText()
    {
        TalkKaren = TalkKarenObject.GetComponent<Text>();
        TalkKaren.text = Karen;
    }

    public void ClickTrue()
    {
        switch (Dankai)
        {
            case 0:
                string talk1 = "き";
                Karen = talk1;
                Destroy(Button1);
                Button2.SetActive(true);
                break;

            case 1:
                string talk2 = "きょ";
                Karen = talk2;
                Destroy(Button2);
                Button3.SetActive(true);
                break;

            case 2:
                string talk3 = "きょう";
                Karen = talk3;
                Destroy(Button3);
                Button4.SetActive(true);
                break;

            case 3:
                string talk4 = "きょうし";
                Karen = talk4;
                Destroy(Button4);
                Button5.SetActive(true);
                break;

            case 4:
                string talk5 = "きょうしつ";
                Karen = talk5;
                Destroy(Button5);
                break;
        }

        ChangeText();
        Dankai++;
        //Active();
    }
   
    public void Clickfalse()
    {

    }

    /*
    private void Active()
    {
        switch (Dankai)
        {
            case 1:
                
                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;

        }
    }
    */
}
