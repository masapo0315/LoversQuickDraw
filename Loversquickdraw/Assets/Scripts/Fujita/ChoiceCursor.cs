using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCursor : MonoBehaviour
{
    //ChoiceManagerから参照してきてもOK
    [SerializeField] private GameObject ChoiceAorX;
    [SerializeField] private GameObject ChoiceBorY;
    [SerializeField] private GameObject ChoiceTrigger;

     public int RightMenu = 2;
     public int LeftMenu = 2;

    [SerializeField] private GameObject Cursor;
    [SerializeField] private GameObject Cursor2;

    //選択肢のポジション
    private Vector3 Rtmp, Ltmp, Dtmp;
 //   private Vector3[] tmp = new Vector3[2];
 
    void Start()
    {
        //それぞれに選択肢のポジションを入れる
        Rtmp = ChoiceAorX.transform.position;
        Ltmp = ChoiceBorY.transform.position;
        Dtmp = ChoiceTrigger.transform.position;

        Debug.Log(Rtmp);
        Debug.Log(Ltmp);
        Debug.Log(Dtmp);
        //for (int i = 0; i < tmp.Length; i++)
        //{
        //    tmp[i] = menuNum[i].transform.position;
        //}
    }
    
    void Update()
    {
        CursorNumber();
        //DebugCursorNumber();
        Select();
    }

    private void CursorNumber()
    {
        //←を押すと1Pを左の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            RightMenu = 0;
        }
        //→を押すと1Pを右の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            RightMenu = 1;
        }
        //↓を押すと1Pを下の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            RightMenu = 2;
        }

        //Aを押すと2Pを左の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft))
        {
            LeftMenu = 0;
        }
        //Dを押すと2Pを右の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight))
        {
            LeftMenu = 1;
        }
        //Sを押すと2Pを下の選択肢に
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown))
        {
            LeftMenu = 2;
        }
    }
    private void DebugCursorNumber()
    {
        //←を押すと1Pを左の選択肢に
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RightMenu = 0;
        }
        //→を押すと1Pを右の選択肢に
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMenu = 1;
        }
        //↓を押すと1Pを下の選択肢に
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RightMenu = 2;
        }

        //Aを押すと2Pを左の選択肢に
        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftMenu = 0;
        }
        //Dを押すと2Pを右の選択肢に
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftMenu = 1;
        }
        //Sを押すと2Pを下の選択肢に
        if (Input.GetKeyDown(KeyCode.S))
        {
            LeftMenu = 2;
        }
    }
    /// <summary>
    /// 上の関数で変わった番号に対応した場所にカーソルを変える
    /// </summary>
    //プレイヤーの操作
    private void Select()
    {
        //1Pの選択
        switch (RightMenu)
        {
            case 0:
                Cursor.transform.position = Rtmp;
                break;

            case 1:
                Cursor.transform.position = Ltmp;
                break;

            case 2:
                Cursor.transform.position = Dtmp;
                break;
        }

        //2Pの選択
        switch (LeftMenu)
        {
            case 0:
                Cursor2.transform.position = Rtmp;
                break;
            case 1:
                Cursor2.transform.position = Ltmp;
                break;
            case 2:
                Cursor2.transform.position = Dtmp;
                break;
        }
    }
}