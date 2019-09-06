using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton : MonoBehaviour
{
    private static Singlton instance = null;
    public static Singlton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singlton();
            }
            return instance;
        }
    }
    //配列[0]がミニゲーム１配列[1]がミニゲーム2の勝利判定
    public int[] WinFlag = new int[2] {0, 0};

    public int Player1LoveMeter;
    public int Player2LoveMeter;

    
}
