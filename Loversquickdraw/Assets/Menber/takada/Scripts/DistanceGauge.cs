﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceGauge : MonoBehaviour {

    //playerのゴールまでの距離に連動してゲージを変化させる

    Slider distanceSlider;
    public GameObject player;

	// Use this for initialization
	void Start () {
        distanceSlider = GetComponent<Slider>();
        player = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        ValuePlus();
	}
    
    //playerのz地点でvalueが変化
    void ValuePlus()
    {
        Vector3 pos = player.transform.position;
        float z = pos.z;

        distanceSlider.value = z;
    }
}