using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer1 : MonoBehaviour
{
    [SerializeField] GameObject player1;

    void Update()
    {
        Vector3 cameraPos = this.player1.transform.position;
        transform.position = new Vector3(cameraPos.x, transform.position.y, transform.position.z);
    }
}
