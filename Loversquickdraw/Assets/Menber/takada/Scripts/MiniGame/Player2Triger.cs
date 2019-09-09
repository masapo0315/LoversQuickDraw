﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Triger : MonoBehaviour {

    [SerializeField] private Player2Controler player2Controler;

    //ジャンプ時のコリジョン判定
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            player2Controler._animator.SetBool("Jump", false);
            player2Controler.jump = false;
        }
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(col.gameObject);
            StartCoroutine("Delay");
        }
    }

    //遅延処理
    private IEnumerator Delay()
    {
        player2Controler.stop = true;
        yield return new WaitForSeconds(2.0f);

        player2Controler.stop = false;
        yield break;
    }
}
