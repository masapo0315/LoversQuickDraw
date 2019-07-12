using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] private AudioClip BGM_Once;
    [SerializeField] private AudioClip BGM_Loop;
    [SerializeField] private bool FirstBGM_Play=true;
    [SerializeField] private AudioClip[] SEData;
    [SerializeField] private AudioSource[] AudioSources;
    [SerializeField] private bool FadeFlag;
    [SerializeField] private float FadeSpeed=0.03f;
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
        FadeOutScript();
	}
    /// <summary>
    /// BGM_Loop BGMはAudioSources[0]使用
    /// </summary>
    void BGMLOOP(){if (!AudioSources[0].isPlaying){
            AudioSources[0].clip = BGM_Loop;
            AudioSources[0].loop = true;
            AudioSources[0].Play();
        }
    }
    /// <summary>
    /// SEを再生する用 AudioSourceが最低でも3個必要
    /// </summary>
    /// <param name="Soundnum">SEData配列番号</param>
    /// <param name="SoundVol">SE音量設定 float0-1</param>
    public void SESounds(int Soundnum, float SoundVol){
        if (SEData[Soundnum] != null){
            for (int i = 1; i <= AudioSources.Length-1; i++)
            {
                if (!AudioSources[i].isPlaying)
                {
                    AudioSources[i].clip = SEData[Soundnum];
                    AudioSources[i].volume = 0.5f;
                    AudioSources[1].Play();
                    break;
                }
            }

            Debug.LogError("サウンドが再生されませんでした。" + " AudioSource不足\n" + "再生されなかったSE:" + Soundnum + " " + SEData[Soundnum].name);
            Debug.LogWarning("再度実行します。");
            SESounds(Soundnum, SoundVol);
        }else Debug.LogError("サウンドが再生されませんでした。"+"SEData配列の"+Soundnum+"番がありません。");
    }
    /// <summary>
    /// シナリオ音声再生する用
    /// </summary>
    /// <param name="Soundnum">SEData配列番号</param>
    /// <param name="SoundVol">SE音量設定 float0-1</param>
    public void SinarioSounds(int Soundnum,float SoundVol){
        if (SEData[Soundnum] != null)
        {
            AudioSources[1].Stop();
            AudioSources[1].clip = SEData[Soundnum];
            AudioSources[1].volume = 0.5f;
            AudioSources[1].Play();
        }
        else Debug.LogError("サウンドが再生されませんでした。" + "SEData配列の" + Soundnum + "番がありません。");
    }
    /// <summary>
    /// 全てのサウンドをフェードアウトする。
    /// </summary>
    void FadeOut(){
        FadeFlag = true;
    }
    /// <summary>
    /// 内部用
    /// </summary>
    void FadeOutScript(){
        if (FadeFlag){
            for (int i=0; i <= AudioSources.Length; i++){
                if (AudioSources[i].volume > 0){
                    AudioSources[i].volume = AudioSources[i].volume - FadeSpeed;
                }
            }
        }
    }
}