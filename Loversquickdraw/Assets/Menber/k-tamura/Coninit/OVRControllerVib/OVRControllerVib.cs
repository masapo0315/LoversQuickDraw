using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRControllerVib : SingletonMonoBehaviour<OVRControllerVib> {
    OVRHapticsClip hapticsClip;
    // Use this for initialization
    void Start () {
        byte[] samples = new byte[1000];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = 128;
        }
        hapticsClip = new OVRHapticsClip(samples, samples.Length);
    }
	
	// Update is called once per frame
	public static void ControllerVib(int i)
    {
        if (i == 0)
        {
            OVRHaptics.LeftChannel.Mix(Instance.hapticsClip);
        }
        else if(i==1)
        {
            OVRHaptics.RightChannel.Mix(Instance.hapticsClip);
        }
    }
}
