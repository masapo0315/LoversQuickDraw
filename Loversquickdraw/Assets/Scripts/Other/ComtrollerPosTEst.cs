using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrollerPosTEst : MonoBehaviour
{
    //comtrollerのposとるのに必須(1Pの場合InspectorからR選択)
    public OVRInput.Controller controller;
    //最高点と最低点のPosを固定
    [SerializeField] private float highPos;
    [SerializeField] private float lowPos;
    
    void Update()
    {
        Test();
    }
    void Test()
    {
        //controllerのposを常に更新する
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        //最高点と今のposを比べる
        if (transform.position.y < highPos)
        {
            //Vector3 vec3 = transform.position;
            float comPosY = highPos - transform.position.y;
            if (comPosY <= 0.3f)
            {
                //加速度を早くする
                Debug.Log("差が小さいから早い");
            }
            else if(comPosY >= 0.3f && 0.6f >= comPosY)
            {
                //加速度を普通にする
                Debug.Log("ふつう");
            }
            else if(comPosY >= 0.6f && 1.0f >= comPosY)
            {
                //加速度を少しゆっくりにする
                Debug.Log("差が広いからゆっくり");
            }
        }

    }
}
