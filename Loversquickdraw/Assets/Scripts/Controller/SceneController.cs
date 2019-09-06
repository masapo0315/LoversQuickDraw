using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private bool once;
    [SerializeField] float waittime;
    [SerializeField] float time;
    private void Start()
    {
        Cursor.visible = false;
        once = false;
    }
    void Update ()
    {
        time += Time.deltaTime;
        if (once == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            {
                once = true;
                SceneLoadManager.LoadScene("Scenario");
            }
            else if (time >= waittime)
            {
                once = true;
                SceneLoadManager.LoadScene("PVScene");
            }
        }
	}
}
