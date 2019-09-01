using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PVManager : MonoBehaviour
{
    [Header("VideoPlayer")]
    [SerializeField]VideoClip VideoClip;
    [SerializeField]VideoPlayer VideoPlayer;
    [SerializeField]float Volume=70;
    [Header("Log")]
    [SerializeField] bool Sceneload;
    [SerializeField] float nowVolume;

    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.SetDirectAudioVolume(0,Volume / 100);
        VideoPlayer.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sceneload)
        {
            if (VideoPlayer.time >= (int)VideoPlayer.clip.length || Input.anyKey)
            {
                SceneLoadManager.LoadScene("Title");
                Sceneload = true;
            }
        }
        else
        {
            while (true)
            {
                if (VideoPlayer.GetDirectAudioVolume(0) <= 0) break;
                nowVolume = VideoPlayer.GetDirectAudioVolume(0) -0.00001f;
                VideoPlayer.SetDirectAudioVolume(0,nowVolume);
            }
        }
    }
}
