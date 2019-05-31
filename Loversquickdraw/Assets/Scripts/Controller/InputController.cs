using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class InputController : MonoBehaviour
{
    //左コン
    [SerializeField] private GameObject Lcube;
    public Text text;
    public Text aaaa;
    private Vector3 L_defPos;
    private Vector3 L_initialPos;
    
    [SerializeField] private float sheikuTime;
    
    private int posGetCount = 0;

    private bool getPosFlag = false;
    
    void Start()
    {
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
        text.text = posGetCount.ToString();
        aaaa.text = L_defPos.y.ToString();
        if (getPosFlag == true && L_defPos.y >= L_initialPos.y + sheikuTime || L_defPos.y <= L_initialPos.y - sheikuTime)
        {
            posGetCount = posGetCount + 1;
            //狭い範囲に入った判定になってる
            //startしたときの値＋0.2fとコントローラーの値を比べてる。わからないことあったら聞いて
            //Debug.Log("L_Con反応アリ");
        }
    }
}
