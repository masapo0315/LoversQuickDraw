using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//岩崎
public class SceneController : MonoBehaviour
{
    //inputManagerからの取得を
    private OVRInput.Button _button;
    private int _buttonNum = 1;
    private void Start()
    {
        _button = InputManager.GetButton(_buttonNum);
        //Debug.Log(_button);
    }
    void Update ()
    {
        //Debug.Log(_button);
        //DebugInput();
        CheckInput(_button);
    }
    private void DebugInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenario");
        }
    }
    private void CheckInput(OVRInput.Button button)
    {
        if(/*SceneManager.GetActiveScene().name == "Title" &&*/ OVRInput.GetDown(button))
        {
            Debug.Log(button);
            SceneManager.LoadScene("Scenario");
        }
    }
}
