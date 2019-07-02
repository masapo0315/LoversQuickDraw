using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour
{
    //　2Pのコントローラー

    //右コン
    [SerializeField] private GameObject Rcube;
    [SerializeField] private float R_shake;
    private Vector3 R_defPos;
    private Vector3 R_initialPos;

    private int R_posGetCount = 0;

    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度

    private Vector3 force;

    float jumpPower = 10f; //ジャンプ力
    bool jump = false;     //設置判定

    [SerializeField]
    Animator _animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
        SpeedUp();
    }

    //加速処理
    private void SpeedUp()
    {
        if (R_posGetCount <= 5)
        {
            R_initialPos.y = R_defPos.y;
            R_posGetCount = R_posGetCount + 1;
        }
        R_defPos = Rcube.transform.position;
        if (R_defPos.y >= R_initialPos.y + R_shake || R_defPos.y <= R_initialPos.y - R_shake)
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
