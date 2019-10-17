using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManeger : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy; 
    public float spawnDelay;

    void SpawnEnemy()
    {
        float randomX = Random.Range(-5.0f, 14.0f); 
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, 5.0f, 0f), Quaternion.identity); //랜덤위에서 Enemy를 하나 생성해줍니다.
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, spawnDelay); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
    }
    void Update()
    {

    }
}