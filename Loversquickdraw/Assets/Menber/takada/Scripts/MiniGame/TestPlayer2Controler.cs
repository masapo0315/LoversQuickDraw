using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer2Controler : MonoBehaviour {

    public Rigidbody rb;
    [SerializeField] float moveSpeed;
    float moveForceMultipliter = 1.0f;

    [SerializeField] float jumpPower;
    bool jump = false;

    bool stop;

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
        if (stop == false)
        {
            SpeedUp();
            Jump();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stopper")
        {
            stop = true;
        }
    }


    //遅延処理
    private IEnumerator Delay()
    {
        stop = true;

        yield return new WaitForSeconds(2.0f);

        stop = false;

        yield break;
    }
}
