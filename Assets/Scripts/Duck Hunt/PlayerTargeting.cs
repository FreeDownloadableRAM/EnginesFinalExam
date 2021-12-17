using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class PlayerTargeting : MonoBehaviour
{
    //DLL
    //DLL imports
    [DllImport("SimplePlugin")]
    private static extern bool normalShot();

    [DllImport("SimplePlugin")]
    private static extern bool silentShot();


    //go to main menu variable
    private int amountOfDucksKilled;
    public int amountOfDucksToWin;

    private bool playSilentShot;
    private bool playNormalShot;

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

        

        //Set internal variables with DLL
        playNormalShot = normalShot();
        playSilentShot = silentShot();

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

            if (playNormalShot == true)
            {
                //play default sound
                //AudioClip.PlayOneShot(firstAudioClip, 0.6F);

            }
            if (playSilentShot == true)
            {
                //play silent shot sound
                //AudioClip.PlayOneShot(secondAudioClip, 0.6F);

            }
            else
            {
                //Play jump Sound
                audioData.Play(0);
            }
            
            //increase duck kills
            amountOfDucksKilled = amountOfDucksKilled + 1;

        }

    }
}
