using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour {

    //　2Pのコントローラー

    public Rigidbody rb;
    float moveSpeed = 10.0f; //速度
    float moveForceMultipliter = 1.0f; // 追従度

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

        SpeedUp();

	}

    // 加速処理
    void SpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal2");
        moveVector.z = moveSpeed * horizontalInput;

        rb.AddForce(moveForceMultipliter * (moveVector - rb.velocity));

    }
}
