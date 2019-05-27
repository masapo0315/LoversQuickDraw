﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class InputController : MonoBehaviour
{
    //左コン
    [SerializeField] private Text L_text;
    [SerializeField] private Text L_debugtext;
    [SerializeField] private GameObject Lcube;
    private int L_count = 0;
    private Vector3 L_defPos;
    private Vector3 L_initialPos;
    
    [SerializeField] private float sheikuTime;
    
    private int posGetCount = 0;

    private bool getPosFlag = false;
    // 1Pのコントローラー
    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度
    [SerializeField] private float moveForceMultipliter; // 追従度

    Vector3 force;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
    }
    void Update()
    {
        /*
         コントローラーを振ったときに一定の範囲内に入ったときにcountが進む
         */
        if (posGetCount <= 5)
        {
            L_initialPos.y = L_defPos.y;
            posGetCount = posGetCount + 1;
        }
        //左コントローラー
        L_defPos = Lcube.transform.position;
        L_text.text = L_defPos.y.ToString();
        L_debugtext.text = L_count.ToString();
        if (L_defPos.y >= L_initialPos.y + sheikuTime || L_defPos.y <= L_initialPos.y - sheikuTime)
        {
            //狭い範囲に入った判定になってる
            //startしたときの値＋0.2fとコントローラーの値を比べてる。わからないことあったら聞いて
            rb.isKinematic = false;
            force = new Vector3(0.0f, 0.0f, 5.0f);
            rb.AddForce(force);  // 力を加える
            L_count = L_count + 1;
            //Debug.Log("L_Con反応アリ");
        }
        else
        {
            rb.velocity = Vector3.zero;
            //rb.isKinematic = true;
        }
    }
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
