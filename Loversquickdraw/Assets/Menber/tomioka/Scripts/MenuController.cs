using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuWindow;

    public void MenuOn()
    {
        MenuWindow.SetActive(true);
    }

    public void MenuOff()
    {
        MenuWindow.SetActive(false);
    }

}
