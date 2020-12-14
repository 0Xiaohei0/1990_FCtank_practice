using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    [SerializeField] GameObject playerNotice;
    [SerializeField] GameObject playerRespawn;
    [SerializeField] float playerSpawnNoticeTime = 1f;
    [SerializeField] GameObject playerObject;
    [SerializeField] int totalPlayerLife = 2;
    [SerializeField] int remainingPlayerLife = 2;
    [SerializeField] GameObject UIcontroller;
    [SerializeField] GameObject[] items;
    [SerializeField] float itemSpawnChance = 0.5f;
    [SerializeField] GameObject unbreakableWalls;
    [SerializeField] float wallEnforceTime = 15f;
    GameObject enforcableWalls;
    GameObject enforcedWalls;

    // Start is called before the first frame update
    void Start()
    {
        remainingPlayerLife = totalPlayerLife;
        UIcontroller.GetComponent<UIControl>().UpdatePlayerLifeCountText(remainingPlayerLife);
        enforcableWalls = GameObject.Find("EnforcableWalls");
        enforcedWalls = GameObject.Find("EnforcedWalls");
        enforcedWalls.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPlayer()
    {
        
       
        StartCoroutine(SpawnPlayerCoroutine());
    }
    IEnumerator SpawnPlayerCoroutine()
    {
        remainingPlayerLife--;
        UIcontroller.GetComponent<UIControl>().UpdatePlayerLifeCountText(remainingPlayerLife);
        if (remainingPlayerLife <= 0)
        {
            gameOver();
        }
        // instantiate notice object
        GameObject notice = Instantiate(playerNotice, playerRespawn.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playerSpawnNoticeTime);
        Destroy(notice);
        // instantiate player object
        Instantiate(playerObject, playerRespawn.transform.position, Quaternion.identity);
    }

    public void gameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
    public void gameWon()
    {
        SceneManager.LoadScene("gameWon");
    }

    // item effects
    public void SpawnItem(Vector3 position)
    {
        System.Random rnd = new System.Random();
        if(rnd.NextDouble() <= itemSpawnChance)
        {
            GameObject itemToSpawn = items[rnd.Next(0, items.Length)];
            Instantiate(itemToSpawn, position, Quaternion.identity);
        }
    }

    public void destoryAllEnemies()
    {
        enemyBehavior[] enemies = FindObjectsOfType<enemyBehavior>();
        foreach (enemyBehavior enemy in enemies)
        {
            enemy.selfDestruct();
        }
    }

    public void enforceWalls()
    {
        enforcableWalls.SetActive(false);
        enforcedWalls.SetActive(true);
        StartCoroutine(turnOffEnforce());
    }
    IEnumerator turnOffEnforce()
    {
        yield return new WaitForSeconds(wallEnforceTime);
        enforcableWalls.SetActive(true);
        enforcedWalls.SetActive(false);
    }
}
