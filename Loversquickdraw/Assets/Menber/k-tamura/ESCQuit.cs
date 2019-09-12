using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCQuit : SingletonMonoBehaviour<ESCQuit> {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F2))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.F4))
        {
            PlayerPrefs.SetString("ScenarioNum", "0");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
