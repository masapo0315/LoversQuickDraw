using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private bool once;
	void Update ()
    {if (once == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            {
                once = true;
                SceneLoadManager.LoadScene("Scenario");
            }
        }
	}
}
