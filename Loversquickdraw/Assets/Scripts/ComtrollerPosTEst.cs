using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrollerPosTEst : MonoBehaviour
{
    public OVRInput.Controller controller;
    void Update()
    {
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        Debug.Log(controller + "のPositionは" + transform.position);
    }
}
