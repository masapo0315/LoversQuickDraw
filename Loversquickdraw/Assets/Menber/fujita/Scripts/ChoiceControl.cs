﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceControl : MonoBehaviour {

    [SerializeField]
    private ChoiceFunctionControl[] _fusenControl = new ChoiceFunctionControl[3];
    private System.Action<int> _callback;
    [SerializeField]
    private ChoiceManager _choiceManager;
    [SerializeField]
    private ChoiceCursor _choiceCursor;
    [SerializeField]
    private TalkManager _talkManager;

    private int _selectnum = 0;

    public void SetSelectMessage(string[] msgs, System.Action<int> callback)
    {
        _callback = callback;
        for (int i = 0; i < 3; i++)
        {
            _fusenControl[i].SetText(msgs[i]);
            _fusenControl[i].gameObject.SetActive(true);
        }
        Debug.Log("ここまで来た");
        _choiceManager.stopChoice = false;
        _choiceManager.cursor.SetActive(true);
        _choiceManager.cursor2.SetActive(true);
        _choiceCursor.DebugCursorNumber();
        //_choiceCursor.CursorNumber();
        //3択の指を表示してせんたくする
        _choiceManager.DebugPushButton();
        //_choiceManager.PushButton();
        _choiceManager.SetSelectCallback(SelectCallback);
    }

    private void SelectCallback(int playerType, int selNum)
    {
        _selectnum = selNum;
        if (_callback != null)
        {
            _callback(_selectnum);
            for (int i = 0; i < 3; i++)
            {
                _fusenControl[i].gameObject.SetActive(false);
            }
        }
        _talkManager._ScenarioSkip = false;
    }
}
