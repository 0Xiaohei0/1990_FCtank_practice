using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemEnforce : itemBehavior
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            FindObjectOfType<sceneController>().enforceWalls();
        base.OnTriggerEnter2D(collision);
        }
    }
}
