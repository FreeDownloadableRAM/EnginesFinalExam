using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class DuckStraightUp : MonoBehaviour
{
    //Initializers

    //set privates
    private Rigidbody2D rb;

    //target
    private Transform target;

    //Speed
    public float movespeed;

    //flapping strength
    private float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        //set speed
       // movespeed = 5f;

        //get rigidbody
        rb = GetComponent<Rigidbody2D>();

        //set target
        target = GameObject.FindGameObjectWithTag("DuckTarget").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //move towards target
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
    }

    
}
