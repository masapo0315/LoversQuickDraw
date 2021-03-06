﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour
{
    //Player2のカメラ固定よう
    [SerializeField] private Camera _camera;
    //　2Pのコントローラー

    //右コン
    //[SerializeField] private GameObject Rcube;
    [SerializeField] private float R_shake;
    private Vector3 R_defPos;
    private Vector3 R_initialPos;

    private int R_posGetCount = 0;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed; //速度

    private Vector3 force;

    [SerializeField] private float jumpPower; //ジャンプ力
    bool jump = false;     //設置判定

    bool stop;

    [SerializeField]
    Animator _animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Delay");
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.localRotation = Quaternion.identity;

        if (stop == false)
        {
            SpeedUp();
            Jump();
        }

    }

    //加速処理
    private void SpeedUp()
    {
        if (R_posGetCount <= 5)
        {
            R_initialPos.y = R_defPos.y;
            R_posGetCount = R_posGetCount + 1;
        }
        //R_defPos = Rcube.transform.position;
        if (R_defPos.y >= R_initialPos.y + R_shake || R_defPos.y <= R_initialPos.y - R_shake || Input.GetKey(KeyCode.D))
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
    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && jump == false)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector3(5, jumpPower, 0);
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
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(col.gameObject);
            StartCoroutine("Delay");
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
