using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] private AudioClip BGM_Once;
    [SerializeField] private AudioClip BGM_Loop;
    [SerializeField] private bool FirstBGM_Play=true;
    [SerializeField] private AudioClip[] SEData;
    [SerializeField] private AudioSource[] AudioSources;
    /// <summary>
    /// Start関数
    /// </summary>
    void Start () {
        if (FirstBGM_Play){
            AudioSources[0].clip = BGM_Once;
            AudioSources[0].playOnAwake = true;

        }

	}
    /// <summary>
    /// Update関数
    /// </summary>
    void Update () {
        if (FirstBGM_Play) BGMLOOP();
	}
    /// <summary>
    /// BGM_Loop
    /// </summary>
    void BGMLOOP(){if (!AudioSources[0].isPlaying){
            AudioSources[0].clip = BGM_Loop;
            AudioSources[0].loop = true;
            AudioSources[0].Play();
        }
    }
    /// <summary>
    /// SEを再生する用 AudioSourceが最低でも2個必要
    /// </summary>
    /// <param name="Soundnum">SEData配列番号</param>
    public void SESounds(int Soundnum){
        for (int i = 1; i <= SEData.Length; i++){
            if (!AudioSources[i].isPlaying){
                AudioSources[i].clip = SEData[Soundnum];
                AudioSources[i].volume = 0.5f;
                AudioSources[1].Play();
                break;
            }
        }
        Debug.LogError("サウンドが再生されませんでした。"+" AudioSound不足\n"+"再生されなかったSE:" + Soundnum + " " + SEData[Soundnum].name);
        Debug.LogWarning("再度実行します。");
        SESounds(Soundnum);
    }
    /// <summary>
    /// 全てのサウンドをフェードアウトする。
    /// </summary>
    void FadeOut(){

    }

}
