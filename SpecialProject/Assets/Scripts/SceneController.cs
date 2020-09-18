using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadNextScene()
    {
        // creates index to find active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //load the next scene
        if (currentSceneIndex < 2)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            //back to start
            SceneManager.LoadScene(0);
        }
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

