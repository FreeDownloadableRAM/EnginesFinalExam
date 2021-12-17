using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class PlayerTargeting : MonoBehaviour
{
    //go to main menu variable
    private int amountOfDucksKilled;
    public int amountOfDucksToWin;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    //get audio component
    AudioSource audioData; //plays the clip in the component

    // Use this for initialization
    void Start()
    {
        //set to zero
        amountOfDucksKilled = 0;

        //Get sound stuff
        audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfDucksKilled == amountOfDucksToWin)
        {
            SceneManager.LoadScene(sceneName: "PlayScreen");

        }
        
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        

    }

    //if it collides with anything it dies.
    public void OnCollisionEnter2D(Collision2D col)
    {
        // When collided with player shot
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);//destroy this game object
            //Play Sound of duck death
            audioData.Play(0);
            //increase duck kills
            amountOfDucksKilled = amountOfDucksKilled + 1;

        }

    }
}
