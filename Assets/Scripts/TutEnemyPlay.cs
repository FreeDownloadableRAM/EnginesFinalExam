using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutEnemyPlay : MonoBehaviour
{
    public void OnButtonPress()
    {
        //Start game
        SceneManager.LoadScene(sceneName: "TutEnemy");

    }
}
