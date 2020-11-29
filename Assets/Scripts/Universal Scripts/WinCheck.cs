using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    private void Update()
    {
        Win();
    }

    void Win()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            SceneManager.LoadSceneAsync("GameWin");
        }
    }
}
