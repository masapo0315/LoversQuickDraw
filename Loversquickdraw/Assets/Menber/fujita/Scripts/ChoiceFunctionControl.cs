using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceFunctionControl : MonoBehaviour {

    [SerializeField]
    private Text _text;

    public void SetText(string msg)
    {
        _text.text = msg;
    }
}
