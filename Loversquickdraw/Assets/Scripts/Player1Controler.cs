using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controler : MonoBehaviour
{
    // 1Pのコントローラー
    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度
    [SerializeField] private float moveForceMultipliter; // 追従度
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
    }
    void Update()
    {
        SpeedUp();
    }
    // 加速処理
    void SpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal");
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
