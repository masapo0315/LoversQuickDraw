using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorController : MonoBehaviour
{
    [HideInInspector]public int RightMenu = 0;
    [HideInInspector]public int LeftMenu = 4;

    [SerializeField]private GameObject Cursor;
    [SerializeField]private GameObject Cursor2;

    //カーソルの位置を決めるオブジェクト
    [SerializeField] private GameObject[] menuNum = new GameObject[5];
    [SerializeField] private MiniGame2Manager miniGame2Manager;

    private Vector3[] tmp = new Vector3[5];
    //1Pと2Pのポジション
    private Vector3 Rtmp, Ltmp;
    
    void Start()
    {
        for(int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = menuNum[i].transform.position;
        }
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("エンター");
            miniGame2Manager.OnSelect1P();
        }

        //2Pの決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("スペースキー");
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
            Debug.Log("右は" + RightMenu);
        }

        //左を押すと左に移動
        //4の次は0に移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (RightMenu == 0)
            {
                RightMenu = 4;
                Debug.Log("右は" + RightMenu);
            }
            else
            {
                RightMenu--;
                RightMenu %= 5;
                Debug.Log("右は" + RightMenu);
            }
        }

        switch (RightMenu)
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftMenu++;
            LeftMenu %= 5;
            Debug.Log("左は" + LeftMenu);
        }

        //Aを押すと左に移動
        //4の次は0に移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (LeftMenu == 0)
            {
                LeftMenu = 4;
                Debug.Log("左は" + LeftMenu);
            }
            else
            {
                LeftMenu--;
                LeftMenu %= 5;
                Debug.Log("左は" + LeftMenu);
            }
        }

        switch (LeftMenu)
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
        Cursor.transform.position = Rtmp;
        Cursor2.transform.position = Ltmp;
    }
}
