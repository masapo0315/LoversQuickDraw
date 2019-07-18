using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtest : MonoBehaviour {
    [SerializeField] SoundManager sound;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void Ok()
    {
        sound.SESounds(0,1);
    }
    public void Not()
    {
        sound.SESounds(1, 1);
    }
}

