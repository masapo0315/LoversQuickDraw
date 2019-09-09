using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSceneChecker : MonoBehaviour {

    TalkManager talkManager;
    bool _once;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TalkManager.Instance._isSeEnd&&!_once)
        {
            _once = true;
            int i = int.Parse(PlayerPrefs.GetString("ScenarioNum"));
            int SNum = i + 1;
            switch (i)
            {
                
                case 0:
                    SceneLoadManager.LoadScene("MiniGame1");
                    PlayerPrefs.SetString("ScenarioNum", SNum.ToString());
                    break;
                case 1:
                    SceneLoadManager.LoadScene("Scenario");
                    PlayerPrefs.SetString("ScenarioNum", SNum.ToString());
                    break;
                case 2:
                    SceneLoadManager.LoadScene("Minigame2");
                    PlayerPrefs.SetString("ScenarioNum", SNum.ToString());
                    break;
                case 3:
                    SceneLoadManager.LoadScene("Scenario");
                    PlayerPrefs.SetString("ScenarioNum", SNum.ToString());
                    break;
                default:
                    SceneLoadManager.LoadScene("Init");
                    break;
            }
           
        }
		
	}
}
