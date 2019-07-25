using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer2Controler : MonoBehaviour {

    public Rigidbody rb;
    float moveSpeed;
    float moveForceMultipliter = 1.0f;

    float jumpPower = 10;
    bool jump = false;

    [SerializeField]
    Animator _animator;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("Delay");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedUp();
        Jump();
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
        if (Input.GetButtonDown("Jump2") && jump == false)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector3(3, jumpPower, 0);
            jump = true;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            _animator.SetBool("Jump", false);
            jump = false;
        }

        if (col.gameObject.tag == "Obstacles" )
        {
            Destroy(col.gameObject);
            StartCoroutine("Delay");
        }
    }


    //遅延処理
    private IEnumerator Delay()
    {
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 15.0f;

        yield break;
    }
}
