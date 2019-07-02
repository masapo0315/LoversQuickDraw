using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer2Controler : MonoBehaviour {

    public Rigidbody rb;
    float moveSpeed = 5.0f;
    float moveForceMultipliter = 1.0f;

    float jumpPower = 10f;
    bool jump = false;

    [SerializeField]
    Animator _animator;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("StartDelay");
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        SpeedUp();
    }

    void SpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal2");
        moveVector.x = moveSpeed * horizontalInput;

        rb.AddForce(moveForceMultipliter * (moveVector - rb.velocity));

        _animator.SetBool("Run", true);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !jump)
        {
            rb.AddForce(Vector3.up * jumpPower);
            jump = true;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        jump = false;
    }


    //遅延処理
    private IEnumerator StartDelay()
    {
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 10.0f;

        yield break;
    }
}
