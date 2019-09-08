using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSceneChecker : MonoBehaviour {

    TalkManager talkManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (talkManager._isSeEnd)
        {
            int i = int.Parse(PlayerPrefs.GetString("ScenarioNum"));
            switch (i)
            {
                case 0:
                    SceneLoadManager.LoadScene("");
                    break;
                case 1:
                    SceneLoadManager.LoadScene("");
                    break;
                default:
                    SceneLoadManager.LoadScene("Init");
                    break;
            }
            PlayerPrefs.SetString("ScenarioNum", i + 1.ToString());
        }
		
	}
}
