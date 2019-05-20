using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{

    [SerializeField]
    GameObject Choice1;
    [SerializeField]
    GameObject Choice2;
    [SerializeField]
    GameObject Choice3;


    bool StopChoice = false;

    float a = 0;

    int hoge = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && StopChoice == false)
        {
            Debug.Log("1を押した");
            hoge = 1;
            Choise1();
            StopChoice = true;

        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && StopChoice == false)
        {
            Debug.Log("2を押した");
            hoge = 2;
            Choise2();
            StopChoice = true;

        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && StopChoice == false)
        {
            Debug.Log("3を押した");
            hoge = 3;
            Choise3();
            StopChoice = true;
        }
    }

    void Choise1()
    {
        Choice2.SetActive(false);
        Choice3.SetActive(false);
        /*
        switch (hoge)
        {
           case :
                Choice2.SetActive(false);
                Choice3.SetActive(false);
                break;
        }

    */
    }

    void Choise2()
    {
        Choice1.SetActive(false);
        Choice3.SetActive(false);
    }

    void Choise3()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

}
