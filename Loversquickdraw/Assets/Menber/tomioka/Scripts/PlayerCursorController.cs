using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorController : MonoBehaviour
{
    public int Player1Menu = 4;
    public int Player2Menu = 0;

    //色を変えるための変数
    [HideInInspector] public bool GetColor;

    [SerializeField] public GameObject Cursor1;
    [SerializeField] public GameObject Cursor2;

    //カーソルの位置を決めるオブジェクト
    [SerializeField] private GameObject[] menuNum = new GameObject[5];
    [SerializeField] private MiniGame2Manager miniGame2Manager;

    private Vector3[] tmp = new Vector3[5];
    //1Pと2Pのポジション
    private Vector3 Rtmp, Ltmp;

    void Start()
    {
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = menuNum[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Select();

        //1Pの決定
        //ルール説明有り版
        //if (miniGame2Manager.Ready1 == true && (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.RawButton.A)))

        //ルール説明無し版
        if (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("エンター");
            GetColor = true;
            miniGame2Manager.OnSelect1P();
        }

        //2Pの決定
        //ルール説明有り版
        //if (miniGame2Manager.Ready2 == true &&(Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.X)))

        //ルール説明無し版
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.X))
        {
           Debug.Log("スペースキー");
            GetColor = false;
            miniGame2Manager.OnSelect2P();
        }
    }

    //プレイヤーの操作
    private void Select()
    {
        //1Pの選択
        //右を押すと右に移動
        //ルール説明有り版
        //if (miniGame2Manager.Ready1 == true &&(Input.GetKeyDown(KeyCode.RightArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)))

        //ルール説明無し版
        if (Input.GetKeyDown(KeyCode.RightArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            Player1Menu++;
            Player1Menu %= 5;
            Debug.Log("右は" + Player1Menu);
        }

        //左を押すと左に移動
        //4の次は0に移動
        //ルール説明有り版
        //if (miniGame2Manager.Ready1 == true && (Input.GetKeyDown(KeyCode.LeftArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)))

        //ルール説明無し版
        if (Input.GetKeyDown(KeyCode.LeftArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            if (Player1Menu == 0)
            {
                Player1Menu = 4;
                Debug.Log("右は" + Player1Menu);
            }
            else
            {
                Player1Menu--;
                Player1Menu %= 5;
                Debug.Log("右は" + Player1Menu);
            }
        }

        switch (Player1Menu)
        {
            case 0:
                Rtmp = tmp[0];
                PositionChange();
                break;

            case 1:
                Rtmp = tmp[1];
                PositionChange();
                break;

            case 2:
                Rtmp = tmp[2];
                PositionChange();
                break;

            case 3:
                Rtmp = tmp[3];
                PositionChange();
                break;

            case 4:
                Rtmp = tmp[4];
                PositionChange();
                break;
        }

        //2Pの選択
        //Dを押すと右に移動
        //ルール説明有り版
        //if (miniGame2Manager.Ready2 == true &&(Input.GetKeyDown(KeyCode.D) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight)))

        //ルール説明無し版 
        if (Input.GetKeyDown(KeyCode.D) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight))
        {
            Player2Menu++;
            Player2Menu %= 5;
            Debug.Log("左は" + Player2Menu);
        }

        //Aを押すと左に移動
        //4の次は0に移動
        //ルール説明有り版
        //if (miniGame2Manager.Ready2 == true &&(Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft)))

        //ルール説明無し版
        if (Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft))
        {
            if (Player2Menu == 0)
            {
                Player2Menu = 4;
                Debug.Log("左は" + Player2Menu);
            }
            else
            {
                Player2Menu--;
                Player2Menu %= 5;
                Debug.Log("左は" + Player2Menu);
            }
        }

        switch (Player2Menu)
        {
            case 0:
                Ltmp = tmp[0];
                PositionChange();
                break;
            case 1:
                Ltmp = tmp[1];
                PositionChange();
                break;
            case 2:
                Ltmp = tmp[2];
                PositionChange();
                break;
            case 3:
                Ltmp = tmp[3];
                PositionChange();
                break;
            case 4:
                Ltmp = tmp[4];
                PositionChange();
                break;
        }
    }

    private void PositionChange()
    {
        Cursor1.transform.position = Rtmp;
        Cursor2.transform.position = Ltmp;
    }
}
