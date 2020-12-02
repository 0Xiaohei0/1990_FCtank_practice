using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] int totalEnemyCount;
    [SerializeField] float enemySpawnNoticeTime = 1f;
    [SerializeField] float enemySpawnWaitTime = 8f;
    [SerializeField] GameObject enemyNotice;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject enemyTankFast;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] enemySpawnQueue;
    [SerializeField] private int spawnindex = 0;

    // debug serialize
    [SerializeField] public int currentEnemyCount = 0;
    [SerializeField] int currentSpawnPointIndex = 0;
    [SerializeField] int enemyToSpawn = 20;

    // timers
    [SerializeField] float SpawnWaitTimer = 0f;



    [SerializeField] GameObject UIcontroller;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemyCount = enemySpawnQueue.Length;
        enemyToSpawn = totalEnemyCount;
        UIcontroller.GetComponent<UIControl>().UpdateEnemyCountText(enemyToSpawn);
        StartCoroutine(SpawnEnemy());
        SpawnWaitTimer = enemySpawnWaitTime;

    }

    IEnumerator SpawnEnemy()
    {
        enemyToSpawn--;
        UIcontroller.GetComponent<UIControl>().UpdateEnemyCountText(enemyToSpawn);
        //UIcontrol.GetComponent<UIControl>().sub1EnemyUI();
        // instantiate notice object
        GameObject notice = Instantiate(enemyNotice, spawnPoints[currentSpawnPointIndex].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(enemySpawnNoticeTime);
        Destroy(notice);
        // instantiate enemy object
        Instantiate(enemySpawnQueue[spawnindex], spawnPoints[currentSpawnPointIndex].transform.position, Quaternion.identity);
        spawnindex++;

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
    public void sub1EnemyCount()
    {
        currentEnemyCount--;
        if (currentEnemyCount <= 0 && enemyToSpawn <= 0)
        {
            GameObject sceneController = GameObject.Find("sceneController");
            sceneController.GetComponent<sceneController>().gameWon();
        }
    }
}
