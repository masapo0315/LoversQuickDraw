﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : SingletonMonoBehaviour<SpriteManager> {
    [Header("Sprite")]
    [SerializeField] Sprite[] SpriteImages;
    [SerializeField] GameObject imageComponent;
    [SerializeField] GameObject imageComponent2;
    [Header("FadeTime")]
    [SerializeField] float fadeTime=2f;
    Color _color;
    static bool isFading;
    float fadeAlpha = 0;
    IEnumerator fadeOut;
    IEnumerator fadeIn;
    private void Start()
    {
        _color = new Vector4(1,1,1,0);
        _color.a = fadeAlpha;
        Instance.imageComponent2.GetComponent<Image>().color = _color;
    }
    private void Update()
    {
        if (isFading)
        {
            _color.a = fadeAlpha;
            Instance.imageComponent2.GetComponent<Image>().color = _color;
        }
    }
    public static void SpriteDisp(int i)
    {
        Instance.imageComponent.GetComponent<Image>().sprite = Instance.SpriteImages[i];
    }
    public static void SpriteSwitch(int i)
    {
        if (i >= 0)
        {
            Debug.Log(Instance.imageComponent.GetComponent<Image>().sprite);
            if (Instance.imageComponent.GetComponent<Image>().sprite == null)
            {
                Instance.imageComponent.GetComponent<Image>().sprite = Instance.SpriteImages[i];
                Instance.StartCoroutine(Instance.FadeInScene(Instance.fadeTime, () =>
                {
                    return;
                }));
            }else
            {
                Instance.imageComponent2.GetComponent<Image>().sprite = Instance.SpriteImages[i];
                Instance.StartCoroutine(Instance.FadeInScene(Instance.fadeTime, () =>
                {
                    Instance.imageComponent2.GetComponent<Image>().color = Instance._color;
                    Instance.imageComponent.GetComponent<Image>().sprite = null;
                    return;
                }));
            }

        } else
        {
            Instance.StartCoroutine(Instance.FadeOutScene(Instance.fadeTime, () =>
            {
                Instance.imageComponent2.GetComponent<Image>().sprite = null;
            }));
            
        }

    }
    IEnumerator FadeInScene(float interval, System.Action callback)
    {
        //だんだん明るく
        isFading = true;
        float time = 0;
        while (time <= interval)
        {
            fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.unscaledDeltaTime;
            yield return 0;
        }

        if (callback != null)
        {
            callback();
        }


    }
    IEnumerator FadeOutScene(float interval, System.Action callback)
    {
        //だんだん暗く
        isFading = true;
        float time = 0;
        while (time <= interval)
        {
            fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.unscaledDeltaTime;
            yield return 0;
        }

        if (callback != null)
        {
            callback();
        }
    }
}

