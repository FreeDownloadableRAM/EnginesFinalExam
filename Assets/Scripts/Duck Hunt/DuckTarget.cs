using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class DuckTarget : MonoBehaviour
{
    //set privates
    private Rigidbody2D rb;

    //target
    private Transform target;

    //Speed
    private float movespeed;

    //check if it hit a wall
    private bool isReflectedBottom = false; //check if reflected, true if it is, false if not
    private bool isReflectedRight = false; //check if reflected, true if it is, false if not
    private bool isReflectedLeft = false; //check if reflected, true if it is, false if not
    private bool isReflectedTop = false; //check if reflected, true if it is, false if not

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody
        rb = GetComponent<Rigidbody2D>();

        //set target
        target = GameObject.FindGameObjectWithTag("WallTop").GetComponent<Transform>();

        //get player Distance
        //playerDistance = Vector2.Distance(target.position, transform.position);

        //set speed
        movespeed = 11f;

        //initial direction
        isReflectedLeft = true; 

}

    // Update is called once per frame
    void Update()
    {
        //move towards walls
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

        /*
        if (isReflectedBottom == true) // reflected off bottom
        {
            //set target
            target = GameObject.FindGameObjectWithTag("WallTop").GetComponent<Transform>();
        }
        if (isReflectedRight == true) // reflected off right
        {
            //set target
            target = GameObject.FindGameObjectWithTag("WallLeft").GetComponent<Transform>();
            
        }
        if (isReflectedLeft == true) // reflected off left
        {
            //set target
            target = GameObject.FindGameObjectWithTag("WallRight").GetComponent<Transform>();
        }
        if (isReflectedTop == true) // reflected off top
        {
            //set target
            target = GameObject.FindGameObjectWithTag("WallBottom").GetComponent<Transform>();
        }
        else
        {
            //set target
            target = GameObject.FindGameObjectWithTag("WallRight").GetComponent<Transform>();
        }
        */
    }

    //Reflect depending on which wall it hits
    public void OnCollisionEnter2D(Collision2D col)
    {

        // When collided
        if (col.gameObject.tag == "WallBottom")
        {
            isReflectedBottom = true;
            //set rest to false
            isReflectedRight = false;
            isReflectedLeft = false;
            isReflectedTop = false;
            //set target
            target = GameObject.FindGameObjectWithTag("WallLeft").GetComponent<Transform>();
        }
        // When collided 
        if (col.gameObject.tag == "WallRight")
        {
            isReflectedRight = true;
            //set rest to false
            isReflectedBottom = false;
            isReflectedLeft = false;
            isReflectedTop = false;
            //set target
            target = GameObject.FindGameObjectWithTag("WallBottom").GetComponent<Transform>();

        }
        // When collided
        if (col.gameObject.tag == "WallLeft")
        {
            isReflectedLeft = true;
            //set rest to false
            isReflectedRight = false;
            isReflectedBottom = false;
            isReflectedTop = false;
            //set target
            target = GameObject.FindGameObjectWithTag("WallTop").GetComponent<Transform>();
        }
        // When collided 
        if (col.gameObject.tag == "WallTop")
        {
            isReflectedTop = true;
            //set rest to false
            isReflectedRight = false;
            isReflectedLeft = false;
            isReflectedBottom = false;
            //set target
            target = GameObject.FindGameObjectWithTag("WallRight").GetComponent<Transform>();
        }
    }


}
