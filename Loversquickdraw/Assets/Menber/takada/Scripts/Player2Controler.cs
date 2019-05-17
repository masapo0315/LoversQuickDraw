using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour {

    //　2Pのコントローラー

    public Rigidbody rb;
    float moveSpeed = 10.0f; //速度
    float moveForceMultipliter = 1.0f; // 追従度

    private OVRInput.Axis2D axis2d;
    private int axisNum;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        axis2d = InputManager.GetAxis2(axisNum);


    }

    // Update is called once per frame
    void Update () {

        PcVersionSpeedUp();
        CheckAxisInput(axis2d);
	}

    private void CheckAxisInput(OVRInput.Axis2D _axis2d)
    {
        OculusVersionSpeedUp();
    }

    //オキュラスコントローラー版の加速処理
    void OculusVersionSpeedUp()
    {

    }

    // PC版の加速処理
    void PcVersionSpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal2");
        moveVector.z = moveSpeed * horizontalInput;

        rb.AddForce(moveForceMultipliter * (moveVector - rb.velocity));

    }
}
