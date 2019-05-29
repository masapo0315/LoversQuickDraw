using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//岩崎
public class FadeManager : MonoBehaviour
{
    private OVRInput.Button _button;
    private int _buttonNum = 1;
    [SerializeField] private float speed;
    private float alfa;
    private float red, green, blue;

    private void Start()
    {
        //Panelの色の取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        _button = InputManager.GetButton(_buttonNum);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckInput(_button);
    }
    private void CheckInput(OVRInput.Button button)
    {
        Fadeout();
    }
    private void Fadein()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa -= speed;
        this.gameObject.SetActive(false);
    }
    private void Fadeout()
    {
        this.gameObject.SetActive(true);
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
    }
}
