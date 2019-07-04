using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorController : MonoBehaviour
{
    [HideInInspector]
    public int RightMenu = 0;
    [HideInInspector]
    public int LeftMenu = 4;

    [SerializeField]
    private GameObject Cursor;
    [SerializeField]
    private GameObject Cursor2;

    [SerializeField]
    private GameObject MenuNumber0;
    [SerializeField]
    private GameObject MenuNumber1;
    [SerializeField]
    private GameObject MenuNumber2;
    [SerializeField]
    private GameObject MenuNumber3;
    [SerializeField]
    private GameObject MenuNumber4;

    [SerializeField]
    private MiniGame2Manager miniGame2Manager;

    private Vector3 tmp0;
    private Vector3 tmp1;
    private Vector3 tmp2;
    private Vector3 tmp3;
    private Vector3 tmp4;

    //1Pと2Pのポジション
    private Vector3 Rtmp;
    private Vector3 Ltmp;

    // Use this for initialization
    void Start()
    {
        tmp0 = MenuNumber0.transform.position;
        tmp1 = MenuNumber1.transform.position;
        tmp2 = MenuNumber2.transform.position;
        tmp3 = MenuNumber3.transform.position;
        tmp4 = MenuNumber4.transform.position;

        //Rtmp;
        //Ltmp;
        /*
        Debug.Log(tmp0);
        Debug.Log(tmp1);
        Debug.Log(tmp2);
        Debug.Log(tmp3);
        Debug.Log(tmp4);
        */
    }

    // Update is called once per frame
    void Update()
    {
        Select();
        
        //1Pの決定
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //Debug.Log("エンター");
            miniGame2Manager.OnSelect1P();
        }

        //2Pの決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("スペースキー");
            miniGame2Manager.OnSelect2P();
        }
    }

    //プレイヤーの操作
    private void Select()
    {
        //1Pの選択
        //右を押すと右に移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMenu++;
            RightMenu %= 5;
            //Debug.Log(RightMenu);
        }

        //左を押すと左に移動
        //4の次は0に移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (RightMenu == 0)
            {
                RightMenu = 4;
                //Debug.Log(RightMenu);
            }
            else
            {
                RightMenu--;
                RightMenu %= 5;
                //Debug.Log(RightMenu);
            }
        }

        switch (RightMenu)
        {
            case 0:
                Rtmp = tmp0;
                PositionChange();
                break;

            case 1:
                Rtmp = tmp1;
                PositionChange();
                break;

            case 2:
                Rtmp = tmp2;
                PositionChange();
                break;

            case 3:
                Rtmp = tmp3;
                PositionChange();
                break;

            case 4:
                Rtmp = tmp4;
                PositionChange();
                break;
        }

        //2Pの選択
        //Dを押すと右に移動
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftMenu++;
            LeftMenu %= 5;
            //Debug.Log(LeftMenu);
        }

        //Aを押すと左に移動
        //4の次は0に移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (LeftMenu == 0)
            {
                LeftMenu = 4;
                //Debug.Log(LeftMenu);
            }
            else
            {
                LeftMenu--;
                LeftMenu %= 5;
                //Debug.Log(LeftMenu);
            }
        }

        switch (LeftMenu)
        {
            case 0:
                Ltmp = tmp0;
                PositionChange();
                break;
            case 1:
                Ltmp = tmp1;
                PositionChange();
                break;
            case 2:
                Ltmp = tmp2;
                PositionChange();
                break;
            case 3:
                Ltmp = tmp3;
                PositionChange();
                break;
            case 4:
                Ltmp = tmp4;
                PositionChange();
                break;
        }



    }

    private void PositionChange()
    {
        Cursor.transform.position = Rtmp;
        Cursor2.transform.position = Ltmp;
    }
}
