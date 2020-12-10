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
    


    // fire
    [SerializeField] GameObject Normal_bullet;
    [SerializeField] GameObject fire_Point;
    [SerializeField] float FireWaitTime = 2f;
    float Firetimer;

    //detection
    [SerializeField] float chanceTurnRight = 0.5f; 
    [SerializeField] GameObject fov;
    [SerializeField] GameObject baseSensor;
    [SerializeField] float TurningWaitTime = 0.25f;
    [SerializeField] float TurningTimer = 0f;
    [SerializeField] bool baseFound = false;


    GameObject enemySpawner;
    sceneController sc;
    [SerializeField] GameObject explosion;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemySpawner = GameObject.Find("enemySpawner");
        sc = FindObjectOfType<sceneController>();
        enemySpawner.GetComponent<enemySpawner>().add1EnemyCount();
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
        if ((obstacleTag == "Wall" || obstacleTag == "Enemy")  && TurningTimer == 0 && baseFound == false)
        {
            randomTurn(chanceTurnRight);//chance of turning right
        }
    }

    public void detectBase()
    {
        baseFound = true;
        
    }

    private void randomTurn(double chanceTurnRight)
    {
        TurningTimer = TurningWaitTime;
        getdirection();
        
        if (UnityEngine.Random.value <= chanceTurnRight)
        {
            z_rotation = transform.rotation.eulerAngles.z + 90;
        }

        else
        {
            z_rotation = transform.rotation.eulerAngles.z - 90;
        }

            
        transform.rotation = Quaternion.Euler(0, 0, z_rotation);
        getdirection();
        
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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            selfDestruct();
        }
    }

    public void selfDestruct()
    {
         enemySpawner.GetComponent<enemySpawner>().sub1EnemyCount();
         Instantiate(explosion, transform.position, Quaternion.identity);
         sc.SpawnItem(transform.position);
         Destroy(gameObject);
    }

    private static bool CheckWithin(float x, float y, float error) => (Math.Abs(x - y) < error);


}
