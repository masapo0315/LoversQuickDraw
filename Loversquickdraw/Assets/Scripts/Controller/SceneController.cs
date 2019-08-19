using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private bool once;
    int _player1;
    private void Start()
    {
        Cursor.visible = false;
        _player1 = LoveMetar.GetPlayer1LoveMetar();
    }
    void Update ()
    {
        if (once == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            {
                once = true;
                SceneLoadManager.LoadScene("Result");
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _player1 += 10;
            Debug.Log("z");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _player1 -= 10;
            Debug.Log("x");
        }
    }
}
