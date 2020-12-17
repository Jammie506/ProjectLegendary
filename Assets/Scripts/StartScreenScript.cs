using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadSceneAsync("Game Scene");
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
