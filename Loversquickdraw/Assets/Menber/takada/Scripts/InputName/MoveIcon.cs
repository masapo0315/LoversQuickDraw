using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour {

    //名前入力のアイコンを動かすためのscript

    //アイコンの移動速度
    [SerializeField]
    private float iconSpeed = Screen.width;
    //アイコンのサイズ取得
    private RectTransform rect;
    //アイコンが画面内に収まる為のオフセット
    private Vector2 offset;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        //オフセット値を設定する
        offset = new Vector2(rect.sizeDelta.x /9f, rect.sizeDelta.y / 10f);
    }

    void Update()
    {

        Move();

    }

    private void Move()
    {
        //移動キーを押していなければ何もしない
        if (Mathf.Approximately(Input.GetAxis("yoko"), 0f) && Mathf.Approximately(Input.GetAxis("tate"), 0f))
        {
            return;
        }
        //移動先を計算する
        var pos = rect.anchoredPosition + new Vector2(Input.GetAxis("yoko") * iconSpeed, Input.GetAxis("tate") * iconSpeed) * Time.deltaTime;

        //アイコンが画面外に出ないようにする
        pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f + offset.x, Screen.width * 0.5f - offset.x);
        pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f + offset.y, Screen.height * 0.5f - offset.y);
        //アイコン位置を設定
        rect.anchoredPosition = pos;
    }
}
