using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceControl : MonoBehaviour {

    [SerializeField]
    private ChoiceFunctionControl[] _fusenControl;
    private System.Action<int> _callback;

    private int _selectnum = 0;

    public void SetSelectMessage(string[] msgs, System.Action<int> callback)
    {
        _callback = callback;
        for (int i = 0; i < 3; i++)
        {
            _fusenControl[i].SetText(msgs[i]);
            _fusenControl[i].gameObject.SetActive(true);
        }
        //3択の指を表示してせんたくする　
    }

    //三択の処理が決定したら呼び出す

    void Update()
    {
        // 三択が決定されたら呼ばれる
        // 三択の番号を取得　_selectNum = ***;
        if (Input.GetMouseButtonDown(0))
        {
            if (_callback != null)
            {
                _callback(_selectnum);
                for (int i = 0; i < 3; i++)
                {
                    _fusenControl[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
