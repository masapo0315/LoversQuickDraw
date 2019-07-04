using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//岩崎
public class SceneController : MonoBehaviour
{
    void Update ()
    {
        if(OVRInput.GetDown(OVRInput.Button.One)||Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoadManager.LoadScene("Scenario");
            //SceneManager.LoadScene("Scenario");
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
