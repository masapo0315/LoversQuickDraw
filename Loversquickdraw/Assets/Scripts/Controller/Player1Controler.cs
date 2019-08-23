using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Player1Controler : MonoBehaviour
{
    //Player1のカメラ固定よう
    [SerializeField] private Camera _camera;
    // 1Pのコントローラー

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
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Delay");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(test.vector3);
        _camera.transform.localRotation = Quaternion.identity;

        if (stop == false)
        {
            //Test();
            Teast2();
            //SpeedUp();
            Jump();
        }
    }

    // 加速処理
    void SpeedUp()
    {
        _animator.SetBool("Run", true);
        force = new Vector3(moveSpeed, 0.0f, 0.0f);
        rb.AddForce(force);

        _animator.SetBool("Run", false);
        rb.velocity = Vector3.zero;

    }
    void Teast2()
    {
        transform.position = OVRInput.GetLocalControllerPosition(controller);

        string posStr = transform.position.ToString("F2");
        //Debug.Log(posStr);
    }

    void Test()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        //最高点と今のposを比べる
        if (transform.position.y < highPos)
        {
            //Vector3 vec3 = transform.position;
            float comPosY = highPos - transform.position.y;
            if (comPosY <= -0.3f)
            {
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed * 1.5f, 0.0f, 0.0f);
                rb.AddForce(force);
                //加速度を早くする
                Debug.Log("差が小さいから早い");
            }
            else if (comPosY >= -0.3f && -0.6f >= comPosY)
            {
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed, 0.0f, 0.0f);
                rb.AddForce(force);
                //加速度を普通にする
                Debug.Log("ふつう");
            }
            else if (comPosY >= -0.6f && -1.0f >= comPosY)
            {
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed * 0.5f, 0.0f, 0.0f);
                rb.AddForce(force);
                //加速度を少しゆっくりにする
                Debug.Log("差が広いからゆっくり");
            }
            else
            {
                _animator.SetBool("Run", false);
                rb.velocity = Vector3.zero;
            }
            Debug.Log(transform.position.y);
        }

    }
    //ジャンプの処理
    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && jump == false)
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
