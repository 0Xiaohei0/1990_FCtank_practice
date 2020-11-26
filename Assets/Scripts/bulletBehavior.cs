using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField]  Rigidbody2D rb;
    [SerializeField] GameObject explosion;
    Vector2 movement;
    float z_rotation;


    void Start()
    {
        getdirection();;
    }

    private void getdirection()
    {
        z_rotation = transform.rotation.eulerAngles.z;
        if (CheckWithin(z_rotation, 0f, 0.1f))
        {
            movement.x = 0;
            movement.y = 1;
        }
        else if (CheckWithin(z_rotation, 90f, 0.1f))
        {
            movement.x = -1;
            movement.y = 0;
        }
        else if (CheckWithin(z_rotation, 180f, 0.1f))
        {
            movement.x = 0;
            movement.y = -1;
        }
        else if (CheckWithin(z_rotation, 270f, 0.1f))
        {
            movement.x = 1;
            movement.y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        rb.position = (rb.position + movement * bulletSpeed * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
        {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    private static bool CheckWithin(float x, float y, float error) => (Math.Abs(x - y) < error);
}
