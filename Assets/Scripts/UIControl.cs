using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject enemyCountUI;
    [SerializeField] GameObject[] list_enemyCountUI;
    [SerializeField] int current_index_list_enemyCountUI;
    [SerializeField] GameObject enemyCountText;
    [SerializeField] GameObject playerLifeCountText;

    // Start is called before the first frame update
    void Start()
    {
        list_enemyCountUI = new GameObject[enemyCountUI.transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            list_enemyCountUI[i] = enemyCountUI.transform.GetChild(i).gameObject;
        }
        current_index_list_enemyCountUI = list_enemyCountUI.Length - 1;
    }

    public void UpdateEnemyCountText(int enemyCount)
    {
        enemyCountText.GetComponent<TextMeshProUGUI>().text = "Enemy to spawn " + enemyCount;
    }
    public void UpdatePlayerLifeCountText(int playerLifeCount)
    {
        playerLifeCountText.GetComponent<TextMeshProUGUI>().text = "Player life " + playerLifeCount;
    }
    public void sub1EnemyUI()
    {
        //if(current_index_list_enemyCountUI >= 0) { 
       // list_enemyCountUI[current_index_list_enemyCountUI].SetActive(false);
       // current_index_list_enemyCountUI--;
        //}
    }
}
