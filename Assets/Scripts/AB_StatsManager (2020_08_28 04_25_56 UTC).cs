using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Written by Andrew Berry
public class AB_StatsManager : MonoBehaviour
{
    public Text healthText;
    public Text crumbText;
    public int health = 100;
    public int crumbs = 0;
    public Image GameOverScreen;
    public AB_UIManager scoreDisplay;

    //Start is called before the first frame update
    private void Start()
    {
        UpdateHealth();
        UpdateCrumbs();
    }

    public void OnGUI()
    {
        if(health <= 0)
        {
            GameOverScreen.gameObject.SetActive(true);
        }
    }

    public void CrumbGet()
    {
        crumbs++;
        UpdateCrumbs();
    }

    public void MoldyCrumbGet()
    {
        crumbs -= 2;
        UpdateCrumbs();
    }

    public void GetHurt()
    {
        health -= 20;
        UpdateHealth();
    }

    public void Victory()
    {
        PlayerPrefs.SetFloat("score", health * crumbs);
        SceneManager.LoadScene("Transition");
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + health;
    }

    private void UpdateCrumbs()
    {
        crumbText.text = "Breadcrumbs: " + crumbs + " / 30";
    }


}
