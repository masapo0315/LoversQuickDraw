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

    [SerializeField]
    Animator _animator;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Delay");
	}
	
	// Update is called once per frame
	void Update ()
    {
        _camera.transform.localRotation = Quaternion.identity;
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
    void Jump()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && jump == false)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector3(3, jumpPower, 0);
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
        moveSpeed = 0f;

        yield return new WaitForSeconds(2.0f);

        moveSpeed = 8.0f;

        yield break;
    }
}
