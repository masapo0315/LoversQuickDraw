using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCursor : MonoBehaviour
{

    [HideInInspector] public int RightMenu = 0;
    [HideInInspector] public int LeftMenu = 2;

    [SerializeField] private GameObject Cursor;
    [SerializeField] private GameObject Cursor2;

    //カーソルの位置を決めるオブジェクト
    [SerializeField] private GameObject[] menuNum = new GameObject[2];

    private Vector3[] tmp = new Vector3[2];
    //1Pと2Pのポジション
    private Vector3 Rtmp, Ltmp;

    // Use this for initialization
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
        }
    }

    private void PositionChange()
    {
        Cursor.transform.position = Rtmp;
        Cursor2.transform.position = Ltmp;
    }
}
