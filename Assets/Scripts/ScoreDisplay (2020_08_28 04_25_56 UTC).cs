using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Andrew Berry

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score: " + PlayerPrefs.GetFloat("score");
    }
}
