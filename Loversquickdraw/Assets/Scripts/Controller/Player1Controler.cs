using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controler : MonoBehaviour {

    // 1Pのコントローラー

    //左コン
    [SerializeField] private GameObject Lcube;
    [SerializeField] private float L_shake;
    private Vector3 L_defPos;
    private Vector3 L_initialPos;

    private int L_posGetCount = 0;

    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度

    private Vector3 force;

    float jumpPower = 10f; //ジャンプ力
    bool jump = false;     //設置判定

    [SerializeField]
    Animator _animator;

    // Use this for initialization
    void Start ()
    {

        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
  
	}
	
	// Update is called once per frame
	void Update ()
    {

        SpeedUp();

	}

    // 加速処理
    void SpeedUp()
    {
        if (L_posGetCount <= 5)
        {
            L_initialPos.y = L_defPos.y;
            L_posGetCount = L_posGetCount + 1;
        }
        L_defPos = Lcube.transform.position;
        if (L_defPos.y >= L_initialPos.y + L_shake || L_defPos.y <= L_initialPos.y - L_shake)
        {
            _animator.SetBool("Run", true);
            force = new Vector3(moveSpeed, 0.0f, 0.0f);
            rb.AddForce(force);
        }
        else
        {
            _animator.SetBool("Run", false);
            rb.velocity = Vector3.zero;
        }
    }

    //ジャンプの処理
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !jump)
        {
            rb.AddForce(Vector3.up * jumpPower);
            _animator.SetBool("Jump", true);
            jump = true;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        _animator.SetBool("Jump", false);
        jump = false;
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
