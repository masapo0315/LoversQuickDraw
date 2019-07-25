using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private bool once;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update ()
    {
<<<<<<< HEAD
        if(OVRInput.GetDown(OVRInput.Button.One))
=======
        if (once == false)
>>>>>>> origin/iwasaki
        {
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            {
                once = true;
                SceneLoadManager.LoadScene("Scenario");
            }
        }
	}
}
