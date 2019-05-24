using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class InputController : MonoBehaviour
{
    //左コン
    [SerializeField] private Text L_text;
    [SerializeField] private Text L_debugtext;
    [SerializeField] private GameObject Lcube;
    private int L_count = 0;
    private Vector3 L_defPos;
    private Vector3 L_initialPos;
    
    //右コン
    [SerializeField] private Text R_text;
    [SerializeField] private Text R_debugtext;
    [SerializeField] private GameObject Rcube;
    private int R_count = 0;
    private Vector3 R_defPos;
    private Vector3 R_initialPos;

    [SerializeField] private float sheikuTime;
    
    private int posGetCount = 0;

    private bool getPosFlag = false;
    
    void Update ()
    {
        /*
         コントローラーを振ったときに一定の範囲内に入ったときにcountが進む
         */
        if(posGetCount <= 5)
        {
            L_initialPos.y = L_defPos.y;
            R_initialPos = R_defPos;
            posGetCount = posGetCount + 1;
        }
       //左コントローラー
        L_defPos = Lcube.transform.position;
        L_text.text = L_defPos.y.ToString();
        L_debugtext.text = L_count.ToString();
        if(L_defPos.y >= L_initialPos.y + sheikuTime || L_defPos.y <= L_initialPos.y - sheikuTime)
        {
            //狭い範囲に入った判定になってる
            //startしたときの値＋0.2fとコントローラーの値を比べてる。わからないことあったら聞いて
            L_count = L_count + 1;
            //Debug.Log("L_Con反応アリ");
        }
        //右コントローラー
        R_defPos = Rcube.transform.position;
        R_text.text = R_defPos.y.ToString();
        R_debugtext.text = R_count.ToString();
        if (R_defPos.y >= R_initialPos.y + sheikuTime || R_defPos.y <= R_initialPos.y - sheikuTime)
        {
            R_count = R_count + 1;
            //Debug.Log("R_Con反応アリ");
        }
    }
}
