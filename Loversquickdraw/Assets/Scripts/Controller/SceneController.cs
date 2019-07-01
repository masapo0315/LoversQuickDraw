using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//岩崎
public class SceneController : MonoBehaviour
{
    void Update ()
    {
<<<<<<< HEAD
        DebugInput();
        CheckInput(_button);
        //Debug.Log(_button);
        if (OVRInput.GetDown(OVRInput.RawButton.A))
=======
        if(OVRInput.GetDown(OVRInput.Button.One))
>>>>>>> 0ead4a3723363a1a8d174c831fdfdfc555555ce7
        {
            SceneManager.LoadScene("Scenario");
            Debug.Log("Aボタン");
        }
       // DebugInput();
    }
    private void DebugInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenario");
        }
    }
}
