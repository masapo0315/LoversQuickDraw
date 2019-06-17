using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceGauge : MonoBehaviour {

    //playerのゴールまでの距離に連動してゲージを変化させる

    float startPos = 1;
    float goalPos = 100;

    private Slider distanceSlider;
    [SerializeField] private GameObject player;

	// Use this for initialization
	void Start () {
        distanceSlider = GetComponent<Slider>();
        player = GetComponent<GameObject>();

        distanceSlider.minValue = startPos;
        distanceSlider.maxValue = goalPos;

	}
	
	// Update is called once per frame
	void Update () {
        ValuePlus();
	}
    
    //playerのX地点でvalueが変化
    void ValuePlus()
    {
        Vector3 pos = player.transform.position;
        float x = pos.x;

        distanceSlider.value = x;
    }
}
