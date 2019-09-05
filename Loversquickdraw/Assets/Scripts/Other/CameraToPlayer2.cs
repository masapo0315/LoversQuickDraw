using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer2 : MonoBehaviour
{
    [SerializeField] GameObject player2;

    void Update()
    {
        Vector3 cameraPos = this.player2.transform.position;
        transform.position = new Vector3(cameraPos.x, transform.position.y, transform.position.z);
    }
}
