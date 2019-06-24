using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField] GameObject[] obstacle;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    // Update is called once per frame
    void Update () {
        ObstacleSporn();
	}

    void ObstacleSporn()
    {
        int num = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[num], new Vector3(Player1.transform.position.x + 5f,-51,0), Quaternion.identity);
        Instantiate(obstacle[num], new Vector3(Player2.transform.position.x + 5f, -99, 0), Quaternion.identity);
    }

}
