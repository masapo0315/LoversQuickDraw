using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	bool onLoad = false;
    [SerializeField] private string SceneLoad="";

	private void Awake()
	{
        Display();InitScript();
	}

    /// <summary>
    /// ディスプレイのサイズを取得して、最大画面で出力する
    /// </summary>
    private void Display()
    {
        int width = Screen.width;
        int height = Screen.height;
        bool fullscreen = true;
        int preferredRefreshRate = 60;

        Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
    }

    /// <summary>
    /// このゲームを初期化する
    /// </summary>
    private void InitScript()
    {

    }
    /// <summary>
    /// Update
    /// </summary>
	void Start()
    {
        SceneLoadManager.LoadScene(SceneLoad);
    }

}
