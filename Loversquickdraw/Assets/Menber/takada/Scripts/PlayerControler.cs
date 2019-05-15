using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float Speed = 10.0f;
    public Rigidbody Player1Rb; //１Pのrigitbody
    public Rigidbody Player2Rb; //２Pのrigitbody

    // Use this for initialization
    void Start () {
        Player1Rb = GetComponent<Rigidbody>();
        Player2Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //スピードアップ
    void SpeedUp()
    {

    }
}
