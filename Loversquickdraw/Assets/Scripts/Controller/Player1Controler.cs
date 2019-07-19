using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Player1Controler : MonoBehaviour
{
    //Player1のカメラ固定よう;
    [SerializeField] private Camera _camera;
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

    [SerializeField]private Animator _animator;

    //comtrollerのposとるのに必須(1Pの場合InspectorからR選択)
    public OVRInput.Controller controller;
    //最高点と最低点のPosを固定
    [SerializeField] private float highPos;
    [SerializeField] private float lowPos;
    //
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Delay");
	}
	//
	void Update ()
    {
        _camera.transform.localRotation = Quaternion.identity;
        //SpeedUp();
        ConShake();
	}
    
    void ConShake()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        //最高点と今のposを比べる
        if (transform.position.y < highPos)
        {
            //Vector3 vec3 = transform.position;
            float comPosY = highPos - transform.position.y;
            if (comPosY <= 0.3f)
            {
                //加速度を早くする
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed, 0.0f, 0.0f);
                rb.AddForce(force);
                Debug.Log("差が小さいから早い");
            }
            else if (comPosY >= 0.3f && 0.6f >= comPosY)
            {
                //加速度を普通にする
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed, 0.0f, 0.0f);
                rb.AddForce(force);
                Debug.Log("ふつう");
            }
            else if (comPosY >= 0.6f && 1.0f >= comPosY)
            {
                //加速度を少しゆっくりにする
                _animator.SetBool("Run", true);
                force = new Vector3(moveSpeed, 0.0f, 0.0f);
                rb.AddForce(force);
                Debug.Log("差が広いからゆっくり");
            }
            else
            {
                _animator.SetBool("Run", false);
                rb.velocity = Vector3.zero;
            }
        }
    }
    // 加速処理
    //void SpeedUp()
    //{
    //    if (L_defPos.y >= L_initialPos.y + L_shake || L_defPos.y <= L_initialPos.y - L_shake)
    //    {
    //        _animator.SetBool("Run", true);
    //        force = new Vector3(moveSpeed, 0.0f, 0.0f);
    //        rb.AddForce(force);
    //    }
    //    else
    //    {
    //        _animator.SetBool("Run", false);
    //        rb.velocity = Vector3.zero;
    //    }
    //}
    //ジャンプの処理
    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && jump == false)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector3(3, jumpPower, 0);
            jump = true;
        }

    }
    //
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
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 15.0f;

        yield break;
    }
}
