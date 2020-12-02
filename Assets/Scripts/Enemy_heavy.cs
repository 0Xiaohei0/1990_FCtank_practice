using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_heavy : enemyBehavior
{
    [SerializeField] int maxLife = 2;
    [SerializeField] private int remainingLife;

    protected override void Start()
    {
        base.Start();
        remainingLife = maxLife;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if(remainingLife <= 0)
            {
                base.OnCollisionEnter2D(collision);
            }
            else
            {
                remainingLife--;
            }
        }
    }
    
}
