using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controler : MonoBehaviour
{
    // 1Pのコントローラー
    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度
    [SerializeField] private float moveForceMultipliter; // 追従度

    //左コン
    [SerializeField] private GameObject Lcube;
    private Vector3 L_defPos;                             
    private Vector3 L_initialPos;                         

    [SerializeField] private float sheikuTime;            

    private int L_posGetCount = 0;               

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
        if (L_posGetCount <= 5)
        {
            L_initialPos.y = L_defPos.y;
            L_posGetCount = L_posGetCount + 1;
        }
        //左コントローラー
        L_defPos = Lcube.transform.position;
        if (L_defPos.y >= L_initialPos.y + sheikuTime || L_defPos.y <= L_initialPos.y - sheikuTime)
        {
            //狭い範囲に入った判定になってる
            //startしたときの値＋0.2fとコントローラーの値を比べてる。わからないことあったら聞いて
            SpeedUp();
            //Debug.Log("L_Con反応アリ");
        }
    }
    // 加速処理
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
