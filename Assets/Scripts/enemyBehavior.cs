using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    // movement
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform enemy_Transform;
    [SerializeField] float movement_speed = 3f;
    Vector2 movement;
    float z_rotation;
    string current_direction = "";
    


    // fire
    [SerializeField] GameObject Normal_bullet;
    [SerializeField] GameObject fire_Point;
    [SerializeField] float FireWaitTime = 2f;
    float Firetimer;

    //detection
    [SerializeField] float chanceTurnRight = 0.5f; 
    [SerializeField] GameObject fov;
    [SerializeField] GameObject baseSensor;
    [SerializeField] float TurningWaitTime = 2f;
    [SerializeField] float TurningTimer = 0f;
 

    // Start is called before the first frame update
    void Start()
    {
        getdirection();
    }

    // Update is called once per frame
    void Update()
    {
        runTimers();
        shoot();
    }
    private void FixedUpdate()
    {
        // if detectObstacle
        // change direction
        // if found homebase
        // keep moving and fire
        rb.position += movement * movement_speed * Time.fixedDeltaTime;


    }

    private void shoot()
    {
        if (Firetimer == 0)
        {
            GameObject bullet = Instantiate(Normal_bullet, fire_Point.transform.position, transform.rotation);
            Firetimer = FireWaitTime;
        }
    }

    private void runTimers()
    {
        if (TurningTimer > 0) { TurningTimer -= Time.deltaTime; }
        else if (TurningTimer < 0) { TurningTimer = 0; }

        if (Firetimer > 0) { Firetimer -= Time.deltaTime; }
        else if (Firetimer < 0) { Firetimer = 0; }
    }

    public void detectObstacle(string obstacleTag)
    {
        if (obstacleTag == "Wall" && TurningTimer == 0)
        {
            randomTurn(chanceTurnRight);//chance of turning right
        }
    }

    private void randomTurn(double chanceTurnRight)
    {
        getdirection();
        
        if (UnityEngine.Random.value <= chanceTurnRight)
        {
            Debug.Log("left");
            z_rotation = transform.rotation.eulerAngles.z + 90;
        }

        else
        {
            Debug.Log("right");
            z_rotation = transform.rotation.eulerAngles.z - 90;
        }

            
        transform.rotation = Quaternion.Euler(0, 0, z_rotation);
        getdirection();
        TurningTimer = TurningWaitTime;
    }

    private void getdirection()
    {
        z_rotation = transform.rotation.eulerAngles.z;
        if(CheckWithin(z_rotation, 0f, 0.1f))
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    private static bool CheckWithin(float x, float y, float error) => (Math.Abs(x - y) < error);


}
