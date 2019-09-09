using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRPosition : SingletonMonoBehaviour<OVRPosition> {

    [SerializeField] float[] _initPosition;
    [SerializeField] float[] _nowPosition;
    [SerializeField] float[] PositionLength;
    public bool _isPosition;
    [SerializeField] float distance=-0.3f;
    public bool _1PTrue;
    public bool _2PTrue;
    public static void InitPosition()
    {
        Instance._initPosition = VRControllerInit.NowVRControllerPos();
    }
    private void Update()
    {
        if (_isPosition)
        {
            if (!_1PTrue || !_2PTrue)
            {
                Instance._nowPosition = VRControllerInit.NowVRControllerPos();
                if (Instance._nowPosition[1] - Instance._initPosition[1] >= distance && !_1PTrue)
                {
                    Instance._1PTrue = true;
                }
                if (Instance._nowPosition[0] - Instance._initPosition[0] >= distance && Instance._2PTrue)
                {
                    Instance._2PTrue = true;
                }
            }

        }
    }
    
}
