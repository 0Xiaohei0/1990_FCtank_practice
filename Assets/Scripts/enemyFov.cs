using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFov : MonoBehaviour
{
    [SerializeField] enemyBehavior enemyBehavior;
    private void OnTriggerStay2D(Collider2D collision)
    {
         enemyBehavior.detectObstacle(collision.tag);
    }
}
