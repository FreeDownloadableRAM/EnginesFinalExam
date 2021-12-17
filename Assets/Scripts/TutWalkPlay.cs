using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutWalkPlay : MonoBehaviour
{
    public void OnButtonPress()
    {
        //Start game
        SceneManager.LoadScene(sceneName: "TutWalk");

    }
}
