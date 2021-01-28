using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class Score : MonoBehaviour
{

    public Text scoreText;  // public if you want to drag your text object in there manually
    public string scoreCounter;

    void Start()
    {
        scoreText = GetComponent<Text>();  // if you want to reference it by code - tag it if you have several texts
        scoreCounter = "Welcome to Capsule Mario!";
    }

    void Update()
    {
        scoreText.text = scoreCounter;  // make it a string to output to the Text object
    }

    public void SetScore(string score)
    {
        if(score == "over")
        {
            scoreCounter = "You Win!";
            return;
        }
        scoreCounter = $"{score} Superjumps left";
    }
}