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
        LoveMetar.player1LoveMetar = 0;
        LoveMetar.player2LoveMetar = 0;
    }
    void Update ()
    {
        time += Time.deltaTime;
        if (once == false)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A) ||OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetKeyDown(KeyCode.Space))
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
