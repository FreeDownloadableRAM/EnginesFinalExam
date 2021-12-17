using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutJumpPlay : MonoBehaviour
{
    public void OnButtonPress()
    {
        //Start game
        SceneManager.LoadScene(sceneName: "TutJump");

    }
}
