using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelect : MonoBehaviour
{
    //最初に選択しておくスクリプト
    [SerializeField] private GameObject firstSelect;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelect);
    }
}
