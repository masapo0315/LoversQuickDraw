using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameControl : MonoBehaviour {

    [SerializeField]
    private ChoiceControl _ChoiceControl;

    private string[] msgs = { "#sentaku", "1", "2", "3" };

    private bool _isSelectMessege = false;
	// Update is called once per frame
	void Update () {
        if (_isSelectMessege)
            return;
        else if (msgs[0].Equals("#sentaku"))
            Choice2Word(msgs);
        else if (msgs[0].Equals("#end"))
            Debug.Log("end");
	}

    private void Choice2Word(string[] msgs)
    {
        //メッセージ表示
        var selMsgs = msgs.Where(x => x.IndexOf("#") < 0).ToArray();
        //_ChoiceControl.SetSlectMessage(selMsgs, SelectCallback);

        _isSelectMessege = true;
    }
    private void SelectCallback(int selectNum)
    {
        _isSelectMessege = false;
        msgs[0] = "#end";
    }
}
