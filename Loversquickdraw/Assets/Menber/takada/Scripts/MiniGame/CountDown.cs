using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    [SerializeField]
    private Image readyImage;
    [SerializeField]
    private Image goImage;


	// Use this for initialization
	void Start () {

        StartCoroutine(CountDownCoroutine());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountDownCoroutine()
    {
        readyImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(12.0f);

        readyImage.gameObject.SetActive(false);
        goImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        goImage.gameObject.SetActive(false);

        yield break;
    }
}
