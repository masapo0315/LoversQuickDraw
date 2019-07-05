using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

	void Update ()
    {
	    if(OVRInput.GetDown(OVRInput.Button.One)||Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoadManager.LoadScene("Scenario");
        }
	}
}
