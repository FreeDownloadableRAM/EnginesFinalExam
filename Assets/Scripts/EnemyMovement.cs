using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class EnemyMovement : MonoBehaviour
{
    //DLL imports
    [DllImport("SimplePlugin")]
    private static extern float EnemyJumpForce();

    [DllImport("SimplePlugin")]
    private static extern float EnemySpeed();

    //A3
    [DllImport("SimplePlugin")]
    private static extern float EnemyAwarenessRange();

    //player distance tracker
    float playerDistance;

    //enemy properties
    private Rigidbody2D rb;
    private float speed;
    //public float speed;
    private float jumpForce;

    //enemy awareness
    private float enemyAwarenessRange = 8f;

    //targeting
    private Transform target;

    //check if on ground
    private bool isGrounded = true; //check if on the ground

    //get audio component
    AudioSource audioData; //plays the clip in the component

    //Optimization Pattern 
    //Dirty Flag
    private bool dirty_; //we use this to 

    //the plan:
    //we dont want the enemies to be checking if we are grounded every frame or not in update
    //so, we set dirty to false at initialization, cause we calculate player position on awake
    //

    // Start is called before the first frame update
    void Start()
    {
        //set dirty to false
        dirty_ = false;

        //Check if DLL works
        Debug.Log(EnemyJumpForce());
        Debug.Log(EnemySpeed());
        Debug.Log(EnemyAwarenessRange());

        //set properties
        //jumpForce = 5f; just to check if DLL really works
        jumpForce = EnemyJumpForce();
        speed = EnemySpeed();
        enemyAwarenessRange = EnemyAwarenessRange();

        rb = GetComponent<Rigidbody2D>();

        //set target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Get sound stuff
        audioData = GetComponent<AudioSource>();

        //get player Distance
        playerDistance = Vector2.Distance(target.position, transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        //player has moved and thus, their position is dirty and needs to be updated.
        //update their distance and set flag to dirt again, and avoid performance being used by cpu
        //since the flag is dirty, you dont need to calculate distance 
        if (dirty_ == true)
        {
            //recalculate player distance
            playerDistance = Vector2.Distance(target.position, transform.position);


            //set to false after
            dirty_ = false;

            //Check if it only runs when player moves
            Debug.Log(playerDistance);
        }
        //if you are within awareness range

        if (playerDistance < enemyAwarenessRange)
        {
            //move towards player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //jump whenever possible
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //toggle variable
                isGrounded = false;

                //Play jump Sound
                audioData.Play(0);
            }

        }
        

        //set flag to dirty whenever player inputs wasd, or arrows
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            dirty_ = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            dirty_ = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            dirty_ = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            dirty_ = true;
        }

    }
   
    //Reset if grounded
    public void OnCollisionEnter2D()
    {
        isGrounded = true;

        //They always jump so play the collide sound
        

    }

}
