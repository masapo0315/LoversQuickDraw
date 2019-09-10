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
    [SerializeField] public Animator _animator;
    [SerializeField] private float moveSpeed; //速度
    [SerializeField] private float jumpPower; //ジャンプ力

    private Vector3 force;

    public bool jump = false;     //設地判定
    public bool stop;
    
    void Start()
    {
        rb = player1.GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
    }
    
    void Update()
    {
        _camera.transform.localRotation = Quaternion.identity;
        _camera.transform.localPosition = new Vector3(0,2,-11f);
        if (stop == false)
        {
            Player1Move();
            Jump();
        }
    }
    // 加速処理
    void SpeedUp(float num)
    {
        _animator.SetBool("Run", true);
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
            _animator.SetBool("Run", false);
            rb.velocity = Vector3.zero;
        }
        SpeedUp(moveSpeed * 0.3f);
    }
    //ジャンプの処理
    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) && jump == false)
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
    private IEnumerator StartDelay()
    {
        stop = true;
        yield return new WaitForSeconds(7.0f);

        stop = false;
        yield break;
    }

    private IEnumerator Delay()
    {
        stop = true;
        yield return new WaitForSeconds(2.0f);

        stop = false;
        yield break;
    }
}