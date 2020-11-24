using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Player_control : MonoBehaviour
{
    // movement
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform player_Transform;
    [SerializeField] float movement_speed = 3f;
    Vector2 movement;

    // fire
    [SerializeField] GameObject Normal_bullet;
    [SerializeField] GameObject fire_Point;
    [SerializeField] float FireWaitTime = 2f;
    float timer;



    string current_direction = "";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // get inputs
    {
        getMoveDirection();
    }

   

    void FixedUpdate()// move player
    {
            changeMovementVector_rotation();
            rb.position = (rb.position + movement * movement_speed * Time.fixedDeltaTime);
        getFireInput();
    }

    private void changeMovementVector_rotation()
    {
        if (current_direction == "")
        {
            movement.y = 0;
            movement.x = 0;
            
        }
        else if (current_direction == "up")
        {
            movement.y = 1;
            movement.x = 0;
            player_Transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (current_direction == "left")
        {
            movement.y = 0;
            movement.x = -1;
            player_Transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if(current_direction == "down")
        {
            movement.y = -1;
            movement.x = 0;
            player_Transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(current_direction == "right")
        {
            movement.y = 0;
            movement.x = 1;
            player_Transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
    private void getMoveDirection()
    {
        // if no current direction look for input
        // else wait for key up
        bool w_pressed = Input.GetKey(KeyCode.D);
        bool a_pressed = Input.GetKey(KeyCode.D);
        bool s_pressed = Input.GetKey(KeyCode.D);
        bool d_pressed = Input.GetKey(KeyCode.D);

        if (current_direction == "") {
            if (Input.GetKey(KeyCode.W)) { current_direction = "up"; }
            else if (Input.GetKey(KeyCode.A)) { current_direction = "left"; }
            else if (Input.GetKey(KeyCode.S)) { current_direction = "down"; }
            else if (Input.GetKey(KeyCode.D)) { current_direction = "right"; }
        }
        else
        {
            if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.S)) || (Input.GetKeyUp(KeyCode.D))){
                current_direction = "";
            }
        }
    }

    private void getFireInput()
    {
        bool fire_pressed = Input.GetKey(KeyCode.Space);
        if (fire_pressed && timer == 0)
        {
            GameObject bullet = Instantiate(Normal_bullet, fire_Point.transform.position, transform.rotation);
            timer = FireWaitTime;
        }
        else if (timer > 0) { timer -= Time.deltaTime; }
        else if (timer < 0) { timer = 0; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
