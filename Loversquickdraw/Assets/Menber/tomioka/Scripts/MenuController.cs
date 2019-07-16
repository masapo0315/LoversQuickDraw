﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Cursor;
    [SerializeField] private GameObject MenuWindow;

    //配列の数もメニューの総数を入れる
    [SerializeField] private GameObject[] menuNum = new GameObject[6];
    //同じく配列の数はメニューの総数を入れる
    private Vector3[] tmp = new Vector3[6];

    //メニューの総数を入れる
    private int MaxMenuNumber = 6;
    private int MenuNumber = 0;
    private bool MenuOn = false;

    private float GetDown = 3;
    //private float GetNow;

    void Start()
    {
        MenuOffCommand();
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = menuNum[i].transform.position;
            //Debug.Log(tmp[i]);
        }
    }


    void Update()
    {
        SceneCommand();
        MenuSelect();
        PushMenu();
        LongPush();

        //コマンドを入れるとメニューが開く
        if (Input.GetKey(KeyCode.Escape) && GetDown <= 0)
        {
            MenuOnCommand();
        }
    }

    private void MenuOnCommand()
    {
        MenuWindow.SetActive(true);
        MenuOn = true;
    }

    private void MenuOffCommand()
    {
        MenuWindow.SetActive(false);
        MenuOn = false;
    }

    private void SceneCommand()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MenuNumber++;
            MenuNumber %= MaxMenuNumber;
            //Debug.Log(MenuNumber);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (MenuNumber == 0)
            {
                MenuNumber = MaxMenuNumber - 1;
                //Debug.Log(MenuNumber);
            }
            else
            {
                MenuNumber--;
                MenuNumber %= MaxMenuNumber;
                //Debug.Log(MenuNumber);
            }
        }
    }


    private void MenuSelect()
    {
        //caseはMaxMenuNumber-1まで
        switch (MenuNumber)
        {
            case 0:
                Cursor.transform.position = tmp[0];
                break;

            case 1:
                Cursor.transform.position = tmp[1];
                break;

            case 2:
                Cursor.transform.position = tmp[2];
                break;

            case 3:
                Cursor.transform.position = tmp[3];
                break;

            case 4:
                Cursor.transform.position = tmp[4];
                break;
            case 5:
                Cursor.transform.position = tmp[5];
                break;
        }
    }

    private void PushMenu()
    {
        if (MenuOn == true && Input.GetKeyDown(KeyCode.Space))
        {
            //caseはMaxMenuNumber-1まで
            switch (MenuNumber)
            {
                case 0:
                    MenuOffCommand();
                    break;

                case 1:
                    SceneManager.LoadScene("Title");
                    break;

                case 2:
                    SceneManager.LoadScene("Scenario");
                    break;

                case 3:
                    SceneManager.LoadScene("Scenario2");
                    break;

                case 4:
                    SceneManager.LoadScene("MiniGame1");
                    break;
                case 5:
                    SceneManager.LoadScene("MiniGame2_test");
                    break;
            }
        }
    }

    private void LongPush()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GetDown -= Time.deltaTime;
            //Debug.Log(GetDown);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GetDown = 3;
        }
    }
}