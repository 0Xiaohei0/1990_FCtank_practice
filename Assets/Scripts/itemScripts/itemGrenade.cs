using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGrenade : itemBehavior
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 
        FindObjectOfType<sceneController>().destoryAllEnemies();
        base.OnTriggerEnter2D(collision);
        }
    }
}
