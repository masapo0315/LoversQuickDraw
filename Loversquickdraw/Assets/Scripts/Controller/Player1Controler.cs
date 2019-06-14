using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controler : MonoBehaviour
{
    //左コン
    [SerializeField] private GameObject Lcube;
    [SerializeField] private float sheikuTime;
    private Vector3 L_defPos;
    private Vector3 L_initialPos;
    
    private int posGetCount = 0;
  
    // 1Pのコントローラー
    [SerializeField] private Rigidbody rb;
    private float moveSpeed; //速度

    private Vector3 force;

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
        if (L_defPos.y >= L_initialPos.y + sheikuTime || L_defPos.y <= L_initialPos.y - sheikuTime)
        {
            //狭い範囲に入った判定になってる
            //startしたときの値＋0.2fとコントローラーの値を比べてる。わからないことあったら聞いて
            force = new Vector3(0.0f, 0.0f, 3.0f);
            rb.AddForce(force);  // 力を加える
            //Debug.Log("L_Con反応アリ");
        }
        else
        {
            rb.velocity = Vector3.zero;
            //rb.isKinematic = true;
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
