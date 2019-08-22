using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastDetector : MonoBehaviour {

    //ボタンを透明にするためのスクリプト

    //使用しているマテリアル
    Material mat;

    private void Start()
    {
        //使用しているマテリアルを取得
        mat = this.GetComponent<Image>().material;

        //マテリアルを透明に
        mat.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
