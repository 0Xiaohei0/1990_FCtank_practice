using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseSensorBehavior : MonoBehaviour
{
    [SerializeField] enemyBehavior enemyBehavior;
    private void OnTriggerStay2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Base")
        {
            enemyBehavior.detectBase();
        }
    }
}
