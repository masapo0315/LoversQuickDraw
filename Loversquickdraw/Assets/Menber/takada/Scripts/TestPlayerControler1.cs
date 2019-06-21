﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerControler1 : MonoBehaviour {

    public Rigidbody rb;
    float moveSpeed = 5.0f;
    float moveForceMultipliter = 1.0f;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");

    }
	
	// Update is called once per frame
	void Update () {

        SpeedUp();

	}

    void SpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal");
        moveVector.x = moveSpeed * horizontalInput;

        rb.AddForce(moveForceMultipliter * (moveVector - rb.velocity));
    }


    private IEnumerator StartDelay()
    {
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 5.0f;

        yield break;
    }
}
