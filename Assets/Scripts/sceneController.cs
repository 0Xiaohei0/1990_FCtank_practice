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
    // Start is called before the first frame update
    void Start()
    {
        remainingPlayerLife = totalPlayerLife;
        UIcontroller.GetComponent<UIControl>().UpdatePlayerLifeCountText(remainingPlayerLife);
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
}
