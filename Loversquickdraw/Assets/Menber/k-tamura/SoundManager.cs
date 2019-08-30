using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

    [SerializeField] private AudioClip BGM_Once;
    [SerializeField] private AudioClip BGM_Loop;
    [SerializeField] private bool FirstBGM_Play = true;
    [SerializeField] private bool FirstBGM_Loop;
    [SerializeField] private AudioClip[] SEData;
    [SerializeField] private AudioSource[] AudioSources;
    [SerializeField] private bool FadeFlag;
    [SerializeField] private float FadeSpeed = 0.03f;
    [SerializeField] private float BGMSoundVolume;
    private bool played;
    /// <summary>
    /// Start関数
    /// </summary>
    void Start()
    {
        if (FirstBGM_Play)
        {
            if (BGM_Once != null)
            {
                AudioSources[0].volume = BGMSoundVolume / 100;
                AudioSources[0].clip = BGM_Once;
                AudioSources[0].Play();
            }
            else
            {
                AudioSources[0].volume = BGMSoundVolume / 100;
                AudioSources[0].clip = BGM_Loop;
                AudioSources[0].loop = true;
                AudioSources[0].Play();
            }
        }

    }
    /// <summary>
    /// Update関数
    /// </summary>
    void Update()
    {
        if (AudioSources[0].loop == false && !AudioSources[0].isPlaying)
        {
            BGMLOOP();
        }
        FadeOutScript();
    }
    /// <summary>
    /// BGM_Loop BGMはAudioSources[0]使用
    /// </summary>
    void BGMLOOP()
    {
        AudioSources[0].volume = BGMSoundVolume / 100;
        AudioSources[0].clip = BGM_Loop;
        AudioSources[0].loop = true;
        AudioSources[0].Play();
    }
    /// <summary>
    /// SEを再生する用 AudioSourceが最低でも3個必要
    /// </summary>
    /// <param name="Soundnum">SEData配列番号</param>
    /// <param name="SoundVol">SE音量設定 float0-1</param>
    public void SESounds(int Soundnum, float SoundVol)
    {
        played = false;
        if (SEData[Soundnum] != null)
        {

            for (int i = 1; i <= AudioSources.Length - 1; i++)
            {
                if (!AudioSources[i].isPlaying)
                {
                    // AudioSources[i].loop = false;
                    // AudioSources[i].clip = SEData[Soundnum];
                    // AudioSources[i].volume = SoundVol;
                    AudioSources[i].PlayOneShot(SEData[Soundnum], SoundVol);
                    played = true;
                    break;
                }
            }

            if (played == false)
            {
                Debug.LogError("サウンドが再生されませんでした。" + " AudioSource不足\n" + "再生されなかったSE:" + Soundnum + " " + SEData[Soundnum].name);
                Debug.LogWarning("再度実行します。");
                SESounds(Soundnum, SoundVol);
            }
        }
        else Debug.LogError("サウンドが再生されませんでした。" + "SEData配列の" + Soundnum + "番がありません。");
    }
    /// <summary>
    /// シナリオ音声再生する用
    /// </summary>
    /// <param name="Soundnum">SEData配列番号</param>
    /// <param name="SoundVol">SE音量設定 float0-1</param>
    public void SinarioSounds(int Soundnum, float SoundVol)
    {
        if (SEData[Soundnum] != null)
        {
            AudioSources[1].Stop();
            AudioSources[1].clip = SEData[Soundnum];
            AudioSources[1].volume = SoundVol;
            AudioSources[1].PlayOneShot(SEData[Soundnum], SoundVol);
        }
        else Debug.LogError("サウンドが再生されませんでした。" + "SEData配列の" + Soundnum + "番がありません。");
    }
    /// <summary>
    /// 全てのサウンドをフェードアウトする。
    /// </summary>
    void FadeOut()
    {
        FadeFlag = true;
    }
    /// <summary>
    /// 内部用
    /// </summary>
    void FadeOutScript()
    {
        if (FadeFlag)
        {
            for (int i = 0; i <= AudioSources.Length; i++)
            {
                if (AudioSources[i].volume > 0)
                {
                    AudioSources[i].volume = AudioSources[i].volume - FadeSpeed;
                }
            }
        }
    }
}