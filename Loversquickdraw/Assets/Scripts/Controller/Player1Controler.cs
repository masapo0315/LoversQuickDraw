using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;

public class Player1Controler : MonoBehaviour
{
    //Player1のカメラ固定よう
    [SerializeField] private Camera _camera;
    // 1Pのコントローラー
    [SerializeField] Text te;

    [SerializeField] GameObject player1;

    //comtrollerのposとるのに必須(1Pの場合InspectorからR選択)
    public OVRInput.Controller controller;

    //最高点と最低点のPosを固定
    [SerializeField] private float highPos;
    [SerializeField] private float lowPos;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed; //速度

    private Vector3 force;
    Test test;

    [SerializeField]
    private float jumpPower; //ジャンプ力
    bool jump = false;     //設地判定

    bool stop;

    [SerializeField]
    Animator _animator;

    // Use this for initialization
    void Start()
    {
        rb = player1.GetComponent<Rigidbody>();
        StartCoroutine("Delay");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(test.vector3);
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

    void Player1Move()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        if (transform.position.y > -0.4f)
        {
            SpeedUp(20f);
        }
        if (transform.position.y < -0.6f)
        {
            SpeedUp(20f);
        }
        if (transform.position.y >= 0f || transform.position.y <= -1)
        {
            _animator.SetBool("Run", true);
            rb.velocity = Vector3.zero;
        }
        te.text = transform.position.y.ToString();
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
    //
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
        //switchで動いたら消す
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
