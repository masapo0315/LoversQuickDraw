using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSceneLoad : MonoBehaviour
{
    float time;
    void Start()
    {
        Application.LoadLevelAdditive("MiniGame1Manual");
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10f)
        {
            Application.UnloadLevel("MiniGame1Manual");

            Destroy(this);
        }
        Debug.Log(time);
    }
}
