using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour {

    //　2Pのコントローラー

    public Rigidbody rb;
    float moveSpeed; //速度
    [SerializeField]
    float moveForceMultipliter; // 追従度

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartDelay());
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

    //遅延処理
    private IEnumerator StartDelay()
    {
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 20.0f;

        yield break;
    }
}
