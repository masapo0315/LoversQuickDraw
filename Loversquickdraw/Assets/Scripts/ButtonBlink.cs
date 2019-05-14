using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルのpush any bottunの点滅
/// </summary>
public class ButtonBlink : MonoBehaviour
{
    [SerializeField]private float speed = 1.0f;

    private Text text;
    private Image image;
    private float time;
    private enum objType
    {
        TEXT,
        IMAGE
    };
    private objType thisobjType = objType.TEXT;

    private void Start()
    {
        //ゲームオブジェクトを判断
        if (this.gameObject.GetComponent<Image>())
        {
            //imageの場合objtypeをimageに変える。
            thisobjType = objType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            //textの場合objtypeをtextに変える。
            thisobjType = objType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }
    }
    private void Update()
    {
        //オブジェクトのAlpha値を更新
        if (thisobjType == objType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if (thisobjType == objType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }
}
