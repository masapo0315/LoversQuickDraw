using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceGauge : MonoBehaviour {

    //playerのゴールまでの距離に連動してゲージを変化させる

    Slider distanceSlider;
    [SerializeField] private GameObject player;

	// Use this for initialization
	void Start () {

        distanceSlider = GetComponent<Slider>();
        //player = GetComponent<GameObject>();
        Debug.Log(player);

        float goalPos = 150;
        float startPos = 1;

        distanceSlider.maxValue = goalPos;
        distanceSlider.value = startPos;

    }
	
	// Update is called once per frame
	void Update () {
        ValuePlus();
	}
    
    //playerのX地点でvalueが変化
    public void ValuePlus()
    {
        Vector3 pos = player.transform.position;
        float x = pos.x;

        distanceSlider.value = x;
    }
}
