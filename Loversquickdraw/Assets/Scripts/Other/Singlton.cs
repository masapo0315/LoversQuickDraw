using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton : MonoBehaviour {

    private static Singlton instance = null;

    public static Singlton Instance
    {
        get
        {
            if (instance == null) instance = new Singlton();

            return instance;
        }
    }

    public static int[] WinFlag = {0, 0,};

}
