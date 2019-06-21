using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    //スタート時のカウントダウン

    public Image readyImage;
    public Image goImage;

	// Use this for initialization
	void Start () {
        StartCoroutine(CountdownCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountdownCoroutine()
    {
        
        readyImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        readyImage.gameObject.SetActive(false);
        goImage.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1.0f);
        goImage.gameObject.SetActive(false);

        yield break;
    }
}
