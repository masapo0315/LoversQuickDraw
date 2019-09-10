using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRPosition : SingletonMonoBehaviour<OVRPosition> {

    [SerializeField] float[] _initPosition;
    [SerializeField] float[] _nowPosition;
    [SerializeField] float[] PositionLength;
    [SerializeField] float _Lcon;
    [SerializeField] float _Rcon;
 public bool _isPosition;
    [SerializeField] float distance=0.3f;
    public bool _1PTrue;
    public bool _2PTrue;
    public static void InitPosition()
    {
        Instance._initPosition = VRControllerInit.NowVRControllerPos();
        Instance._Lcon = Instance._initPosition[1];
        Instance._Rcon = Instance._initPosition[0];

       // Debug.LogWarning("initpos");
    }
    private void Update()
    {
        if (_isPosition)
        {
            if (!_1PTrue || !_2PTrue)
            {
                Instance._nowPosition = VRControllerInit.NowVRControllerPos();
                Instance.PositionLength[0] = Instance._nowPosition[0] - Instance._Rcon;
                Instance.PositionLength[1] = Instance._nowPosition[1] - Instance._Lcon;

                if (Instance.PositionLength[1]>=Instance.distance && Instance._1PTrue==false)
                {
                    
                    Debug.Log(Instance._initPosition[1] - Instance._nowPosition[1]);
                    Instance._1PTrue = true;
                }
                if (Instance.PositionLength[0]>=Instance.distance && Instance._2PTrue==false)
                {
                    Instance._2PTrue = true;
                }
            }

        }
    }
    
}
