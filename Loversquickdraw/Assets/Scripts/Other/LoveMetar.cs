using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMetar : MonoBehaviour {

    //好感度

    public static int player1LoveMetar; //１Pの好感度
    public static int player2LoveMetar; //２Pの好感度


    //getter

    public static int getPlayer1LoveMetar()
    {
        return player1LoveMetar;
    }

    public static int getPlayer2LoveMetar()
    {
        return player2LoveMetar;
    }

}
