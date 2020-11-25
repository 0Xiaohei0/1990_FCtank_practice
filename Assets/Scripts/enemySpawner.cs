using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] int totalEnemyCount = 20;
    [SerializeField] float enemySpawnNoticeTime = 1f;
    [SerializeField] float enemySpawnWaitTime = 8f;
    [SerializeField] GameObject enemyNotice;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject[] spawnPoints;

    // debug serialize
    [SerializeField] public int currentEnemyCount = 0;
    [SerializeField] int currentSpawnPointIndex = 0;
    [SerializeField] int enemyToSpawn = 20;

    // timers
    [SerializeField] float SpawnWaitTimer = 0f;



    [SerializeField] GameObject UIcontrol;

    // Start is called before the first frame update
    void Start()
    {
        enemyToSpawn = totalEnemyCount;
        StartCoroutine(SpawnEnemy());
        SpawnWaitTimer = enemySpawnWaitTime;
    }

    IEnumerator SpawnEnemy()
    {
        //UIcontrol.GetComponent<UIControl>().sub1EnemyUI();
        // instantiate notice object
        GameObject notice = Instantiate(enemyNotice, spawnPoints[currentSpawnPointIndex].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(enemySpawnNoticeTime);
        Destroy(notice);
        // instantiate enemy object
        Instantiate(enemyTank, spawnPoints[currentSpawnPointIndex].transform.position, Quaternion.identity);
        enemyToSpawn--;

        //cycle currentSpawnPointIndex
        if ((currentSpawnPointIndex + 1) < (spawnPoints.Length)){
            currentSpawnPointIndex++;
        }
        else
        {
            currentSpawnPointIndex = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        runTimers();
        if(SpawnWaitTimer == 0 && enemyToSpawn > 0)
        {
            StartCoroutine(SpawnEnemy());
            SpawnWaitTimer = enemySpawnWaitTime;
        }
    }

    private void runTimers()
    {
        if (SpawnWaitTimer > 0) { SpawnWaitTimer -= Time.deltaTime; } else if (SpawnWaitTimer < 0) { SpawnWaitTimer = 0; }
    }

    public void add1EnemyCount() => currentEnemyCount++;
    public void sub1EnemyCount() => currentEnemyCount--;
}
