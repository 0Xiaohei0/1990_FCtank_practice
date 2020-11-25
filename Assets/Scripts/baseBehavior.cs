using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Bullet" || tag == "EnemyBullet")
        {
            GameObject sceneController = GameObject.Find("sceneController");
            sceneController.GetComponent<sceneController>().gameOver();
            Destroy(gameObject);
        }
    }
}
