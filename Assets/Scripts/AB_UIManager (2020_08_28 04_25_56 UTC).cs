using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Written by Andrew Berry

public class AB_UIManager : MonoBehaviour
{
    public int currentLevel;
    public bool isFinalLevel;

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevel()
    {
        if (!isFinalLevel)
            SceneManager.LoadScene(currentLevel + 1);
        else
            SceneManager.LoadScene("Main Menu"); //or a victory screen or something
    }
}
