using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour
{
    //comtrollerのposとるのに必須(1Pの場合InspectorからL選択)
    public OVRInput.Controller _controller;

    //Player2のカメラ固定よう
    [SerializeField] private Camera _camera;

    //2Pコントローラー
    [SerializeField] private GameObject player2;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Animator _animator;
    [SerializeField] private float moveSpeed; //速度
    [SerializeField] private float jumpPower; //ジャンプ力

    private Vector3 force;

    public bool jump = false;     //設置判定
    public bool stop;
    
    void Start()
    {
        rb = player2.GetComponent<Rigidbody>();
        StartCoroutine("Delay");
    }
    
    void Update()
    {
        _camera.transform.localRotation = Quaternion.identity;
        _camera.transform.localPosition = new Vector3(0,-29.5f,-11);
        if (stop == false)
        {
            Player2Move();
            Jump();
        }
    }
    //加速処理
    private void SpeedUp(float num)
    {
        _animator.SetBool("Run", false);
        force = new Vector3(num, 0f, 0f);
        rb.AddForce(force);
    }
    //プレイヤー2の移動
    void Player2Move()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(_controller);
        //controllerのPosが一定の範囲内ならを分岐で
        if (transform.position.y > -0.4f)
        {
            SpeedUp(moveSpeed);
            _animator.SetBool("Run", true);
        }
        if (transform.position.y < -0.6f)
        {
            SpeedUp(moveSpeed);
            _animator.SetBool("Run", true);
        }
        if (transform.position.y >= 0f || transform.position.y <= -1)
        {
            _animator.SetBool("Run", true);
            rb.velocity = Vector3.zero;
        }
    }
    //ジャンプの処理
    public void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X) && jump == false)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector3(5, jumpPower, 0);
            jump = true;
        }
    }
    //ジャンプ時のコリジョン判定
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