using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NJ_UI_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Noah Johanson");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Next()
    {
        SceneManager.LoadScene("John");
    }

    public void FirstLVL()
    {
        SceneManager.LoadScene("Andrew");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
