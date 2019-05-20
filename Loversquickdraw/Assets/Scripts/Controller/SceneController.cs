using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//岩崎
public class SceneController : MonoBehaviour
{
    private OVRInput.Button _button;
    private int _buttonNum = 1;
    private void Start()
    {
        _button = InputManager.GetButton(_buttonNum);
        Debug.Log(_button);
    }
    void Update ()
    {
        CheckInput(_button);
	}
    private void CheckInput(OVRInput.Button button)
    {
        if(OVRInput.GetDown(button))
        {
            Debug.Log(button);
            SceneManager.LoadScene("Sinario");
        }
    }
}
