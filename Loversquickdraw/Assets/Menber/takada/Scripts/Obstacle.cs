using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    //障害物を生成

    [SerializeField] GameObject[] obstacle;
    [SerializeField] GameObject spawnPoint;

    private void Start()
    {
        int num = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[num], new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y,spawnPoint.transform.position.z),Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {

    }
}
