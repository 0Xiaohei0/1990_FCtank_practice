using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWallBehavior : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}
