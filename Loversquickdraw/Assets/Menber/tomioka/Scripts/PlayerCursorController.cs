using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorController : MonoBehaviour
{
    public int _player1Menu = 4;
    public int _player2Menu = 0;

    //色を変えるための変数
    [HideInInspector] public bool _getColor;

    [SerializeField] public GameObject _cursor1;
    [SerializeField] public GameObject _cursor2;

    //カーソルの位置を決めるオブジェクト
    [SerializeField] private GameObject[] _MenuNum = new GameObject[5];
    [SerializeField] private MiniGame2Manager miniGame2Manager;

    private Vector3[] tmp = new Vector3[5];
    //1Pと2Pのポジション
    private Vector3 _Rtmp, _Ltmp;

    void Start()
    {
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = _MenuNum[i].transform.position;
        }
    }

    void Update()
    {
        Select();

        //1Pの決定
        if (miniGame2Manager._ready1 == true && (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.RawButton.A)))
        {
            //Debug.Log("エンター");
            _getColor = true;
            miniGame2Manager.SelectSwitch1P();
        }

        //2Pの決定
        if (miniGame2Manager._ready2 == true && (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.X)))
        {
            //Debug.Log("スペースキー");
            _getColor = false;
            miniGame2Manager.SelectSwitch2P();
        }
    }

    //プレイヤーの操作
    private void Select()
    {
        //1Pの選択
        //右を押すと右に移動
        if (miniGame2Manager._ready1 == true && (Input.GetKeyDown(KeyCode.RightArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)))
        {
            _player1Menu++;
            _player1Menu %= 5;
            //Debug.Log("右は" + _player1Menu);
        }

        //左を押すと左に移動
        //4の次は0に移動
        if (miniGame2Manager._ready1 == true && (Input.GetKeyDown(KeyCode.LeftArrow) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)))
        {
            if (_player1Menu == 0)
            {
                _player1Menu = 4;
                //Debug.Log("右は" + _player1Menu);
            }
            else
            {
                _player1Menu--;
                _player1Menu %= 5;
                //Debug.Log("右は" + _player1Menu);
            }
        }

        switch (_player1Menu)
        {
            case 0:
                _Rtmp = tmp[0];
                PositionChange();
                break;

            case 1:
                _Rtmp = tmp[1];
                PositionChange();
                break;

            case 2:
                _Rtmp = tmp[2];
                PositionChange();
                break;

            case 3:
                _Rtmp = tmp[3];
                PositionChange();
                break;

            case 4:
                _Rtmp = tmp[4];
                PositionChange();
                break;
        }

        //2Pの選択
        //Dを押すと右に移動
        if (miniGame2Manager._ready2 == true && (Input.GetKeyDown(KeyCode.D) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight)))
        {
            _player2Menu++;
            _player2Menu %= 5;
            //Debug.Log("左は" + _player2Menu);
        }

        //Aを押すと左に移動
        //4の次は0に移動
        if (miniGame2Manager._ready2 == true && (Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft)))
        {
            if (_player2Menu == 0)
            {
                _player2Menu = 4;
                //Debug.Log("左は" + _player2Menu);
            }
            else
            {
                _player2Menu--;
                _player2Menu %= 5;
                //Debug.Log("左は" + _player2Menu);
            }
        }

        switch (_player2Menu)
        {
            case 0:
                _Ltmp = tmp[0];
                PositionChange();
                break;
            case 1:
                _Ltmp = tmp[1];
                PositionChange();
                break;
            case 2:
                _Ltmp = tmp[2];
                PositionChange();
                break;
            case 3:
                _Ltmp = tmp[3];
                PositionChange();
                break;
            case 4:
                _Ltmp = tmp[4];
                PositionChange();
                break;
        }
    }

    private void PositionChange()
    {
        _cursor1.transform.position = _Rtmp;
        _cursor2.transform.position = _Ltmp;
    }
}
