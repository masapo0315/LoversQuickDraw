using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controler : MonoBehaviour
{
    //comtrollerのposとるのに必須(1Pの場合InspectorからR選択)
    public OVRInput.Controller controller;

    //Player1のカメラ固定よう
    [SerializeField] private Camera _camera;

    // 1Pのコントローラー
    [SerializeField] private GameObject player1;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed; //速度
    [SerializeField] private float jumpPower; //ジャンプ力
    [SerializeField] private Animator _animator;

    private Vector3 force;

    private bool jump = false;     //設地判定
    private bool stop;
    
    void Start()
    {
        rb = player1.GetComponent<Rigidbody>();
        StartCoroutine("Delay");
    }
    
    void Update()
    {
        _camera.transform.localRotation = Quaternion.identity;
        _camera.transform.localPosition = Vector3.zero;
        if (stop == false)
        {
            Player1Move();
            Jump();
        }
    }
    // 加速処理
    void SpeedUp(float num)
    {
        _animator.SetBool("Run", false);
        force = new Vector3(num, 0.0f, 0.0f);
        rb.AddForce(force);
    }
    //プレイヤー1の移動
    void Player1Move()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        //controllerのPosが一定の範囲内ならを分岐で
        if (transform.position.y > -0.4f)
        {
            SpeedUp(moveSpeed);
        }
        if (transform.position.y < -0.6f)
        {
            SpeedUp(moveSpeed);
        }
        if (transform.position.y >= 0f || transform.position.y <= -1)
        {
            _animator.SetBool("Run", true);
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
    //ジャンプ時のコリジョン判定
    private void OnCollisionEnter(Collision col)
    {
        switch(col.gameObject.tag)
        {
            case "ground":
                _animator.SetBool("Jump", false);
                jump = false;
                break;
            case "Obstacles":
                Destroy(col.gameObject);
                StartCoroutine("Delay");
                break;
        }
        /*
        if (col.gameObject.tag == "ground")
        {
            _animator.SetBool("Jump", false);
            jump = false;
        }
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(col.gameObject);
            StartCoroutine("Delay");
        }*/
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