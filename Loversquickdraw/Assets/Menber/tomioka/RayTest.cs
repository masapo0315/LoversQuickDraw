using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayTest : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RayTestA();
        }
    }

    void RayTestA()
    {
        //Ray SubRay = new Ray(Input.mousePosition);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red, 5);
            //Debug.Log("");
            Debug.Log(hit.transform.position);
            Debug.Log(hit);
        }
    }

}
