using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpos : MonoBehaviour {
    [SerializeField] OVRInput.Controller L;
    [SerializeField] OVRInput.Controller R;
    [SerializeField] bool _vive;
    [SerializeField]GameObject cube1;
    [SerializeField] GameObject cube2;
    public AudioClip audioClip;
    OVRHapticsClip hapticsClip;
    private void Start()
    {
        byte[] samples = new byte[1000];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = 128;
        }
        hapticsClip = new OVRHapticsClip(samples, samples.Length);
    }

    void Update () {
        float[] i = VRControllerInit.NowVRControllerPos();
       // Debug.Log(i[0] + " " + i[1]);
        cube1.GetComponent<Transform>().position =new Vector3(0,0,i[1]*100);
        cube2.GetComponent<Transform>().position = new Vector3(0, 0, i[0]*100);
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("push");
            OVRHaptics.LeftChannel.Mix(hapticsClip);
        }

    }
}
