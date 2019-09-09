using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Trigger : MonoBehaviour {

    [SerializeField] private Player1Controler player1Controler;

    //ジャンプ時のコリジョン判定
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            player1Controler._animator.SetBool("Jump", false);
            player1Controler.jump = false;
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
        player1Controler.stop = true;
        yield return new WaitForSeconds(2.0f);

        player1Controler.stop = false;
        yield break;
    }
}
