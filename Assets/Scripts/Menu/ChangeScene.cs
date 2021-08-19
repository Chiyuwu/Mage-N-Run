using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public static void switchToScene(int sceneId) // Switch to scene ID
    {
        
        SceneManager.LoadScene(sceneId); // Game start --> switch to forest level scene
    }

    public void quitGame()
    {
        Application.Quit(); //Game exit
    }
}
