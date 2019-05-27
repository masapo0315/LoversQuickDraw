using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour
{

    //　2Pのコントローラー

    public Rigidbody rb;
    float moveSpeed; //速度
    [SerializeField]
    float moveForceMultipliter; // 追従度

    //右コン
    [SerializeField] private GameObject Rcube; 
    private Vector3 R_defPos;            
    private Vector3 R_initialPos;                   

    [SerializeField] private float sheikuTime;      

    private int R_posGetCount = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
        //                 
        if (R_posGetCount <= 5)
        {
            R_initialPos = R_defPos;
            R_posGetCount = R_posGetCount + 1;
        }
        //右コントローラー
        R_defPos = Rcube.transform.position;
        if (R_defPos.y >= R_initialPos.y + sheikuTime || R_defPos.y <= R_initialPos.y - sheikuTime)
        {
            SpeedUp();
            //Debug.Log("R_Con反応アリ");
        }
    }

    // 加速処理
    void SpeedUp()
    {
        Vector3 moveVector = Vector3.zero;
        float horizontalInput = Input.GetAxis("Horizontal2");
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
