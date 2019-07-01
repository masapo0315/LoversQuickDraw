using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void PlayerMouseMove()
    {
        int Speed = 6;
        var xpos = Input.GetAxis("Horizontal");
        var ypos = Input.GetAxis("Vertical");
        var pos = GetComponent<RectTransform>().localPosition;

        pos.x += Speed * xpos;
        pos.y += Speed * ypos;
        GetComponent<RectTransform>().localPosition = pos;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouseMove();
    }
}
