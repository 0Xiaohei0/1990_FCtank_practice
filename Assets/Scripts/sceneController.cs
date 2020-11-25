using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
    [SerializeField] GameObject playerNotice;
    [SerializeField] GameObject playerRespawn;
    [SerializeField] float playerSpawnNoticeTime = 1f;
    [SerializeField] GameObject playerObject;
    [SerializeField] int totalPlayerLife = 2;
    [SerializeField] int remainingPlayerLife = 2;
    // Start is called before the first frame update
    void Start()
    {
        remainingPlayerLife = totalPlayerLife;
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
        if(remainingPlayerLife <= 0)
        {
            gameOver();
        }
        // instantiate notice object
        GameObject notice = Instantiate(playerNotice, playerRespawn.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(notice);
        // instantiate player object
        Instantiate(playerObject, playerRespawn.transform.position, Quaternion.identity);
    }

    public void gameOver()
    {
        Debug.Log("Game Over!");
    }
}
