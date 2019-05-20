using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject Lcube;
    [SerializeField] private GameObject Rcube;
    [SerializeField] private Text L_text;
    [SerializeField] private Text R_text;

    private Vector3 L_defPos;
    private Vector3 R_defPos;

    private int L_count = 0;
    private int R_count = 0;

    private bool L_Concheck = false;
    private bool R_Concheck = false;

    private void Start()
    {
        L_defPos = Lcube.transform.position;
        R_defPos = Rcube.transform.position;
    }

    void Update ()
    {
        L_text.text = Lcube.transform.position.y.ToString();
        R_text.text = Rcube.transform.position.y.ToString();
        //Debug.Log(L_defPos.y);
        //Debug.Log(R_defPos.y);
        if (L_Concheck == false && Lcube.transform.position.y < L_defPos.y + 0.02f && Lcube.transform.position.y > L_defPos.y - 0.02f)
        {
            L_Concheck = true;
        }
        if (L_Concheck == true)
        {
            L_count = L_count + 1;
            Debug.Log(L_count);
            Debug.Log("L_Con反応アリ");
            L_Concheck = false;
        }

        if (R_Concheck == false && Rcube.transform.position.y < R_defPos.y + 0.02f && Rcube.transform.position.y > R_defPos.y - 0.02f)
        {
            R_Concheck = true;
        }
        if(R_Concheck == true)
        {
            R_Concheck = false;
            R_count = R_count + 1;
            Debug.Log(L_count);
            Debug.Log("R_Con反応アリ");
        }
    }
}
