using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class FadeManager : MonoBehaviour
{
    [SerializeField] private float speed;
    private float red, green, blue, alfa;

    private void Start()
    {
        //Panelの色の取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        this.gameObject.SetActive(false);
    }
    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fadeout();
        }
    }
    private void CheckInput(OVRInput.Button button)
    {
        Fadeout();
    }
    //fadein
    private void Fadein()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa -= speed;
        this.gameObject.SetActive(false);
    }
    //fadeout
    private void Fadeout()
    {
        this.gameObject.SetActive(true);
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
    }
}
