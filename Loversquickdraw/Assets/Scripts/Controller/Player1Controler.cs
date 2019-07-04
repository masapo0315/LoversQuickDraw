using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Player1Controler : MonoBehaviour
{
    //Player1のカメラ固定よう
    [SerializeField] private Camera _mainCamera;
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

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
	}
	
	// Update is called once per frame
	void Update ()
    {
        _mainCamera.transform.localRotation = Quaternion.identity;
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
            force = new Vector3(3.0f, 0.0f, 0.0f);
            rb.AddForce(force);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
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
