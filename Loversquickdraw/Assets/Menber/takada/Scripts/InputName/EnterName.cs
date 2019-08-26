using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour {

    //名前を決定するときに使う

    [SerializeField]
    private Text enterName;

    [SerializeField]
    private GameObject input;

    [SerializeField]
    private GameObject Confirmation;

    private void Update()
    {
        //入力した名前をテキストに反映
        enterName.text = InputName.Player1Name;
    }

    //名前を決定
    public void Enter()
    {
        SceneManager.LoadScene("");
    }

    //名前を決定しない
    public void NotEnter()
    {
        Confirmation.SetActive(false);
        input.SetActive(true);
    }


}
