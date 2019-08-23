using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundContorol : MonoBehaviour {

    //カメラの動きに合わせて背景を回り込みさせる


    //背景の枚数
    int spritecount = 3;

    //背景の回り込み
    float rightOffset = 1.45f;
    float leftOffset = 20f;

    Transform bgTfm;
    SpriteRenderer spriteRenderer;
    float width;

	// Use this for initialization
	void Start () {

        bgTfm = transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;

	}
	
	// Update is called once per frame
	void Update () {

        SpriteAround();

	}

    void SpriteAround(){

        //座標変換
        Vector3 viewPoint = Camera.main.WorldToViewportPoint(bgTfm.position);

        //背景の回り込み
        if (viewPoint.x < leftOffset) {

            bgTfm.position += Vector3.right * (width * spritecount);

        } else if (viewPoint.x > rightOffset){
            bgTfm.position -= Vector3.right * (width * spritecount);
        }

    }
}
