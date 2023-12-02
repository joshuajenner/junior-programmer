using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static int lives = 10;

    public void Start()
    {
        DisplayScore();
        DisplayLives();
    }

    public static void IncrementScore() 
    {
        score += 1;
        DisplayScore();
    }
    public static void DisplayScore()
    {
        Debug.Log("Score: " + score);
    }

    public static void DecrementLives()
    {
        lives -= 1;
        if (lives <= 0)
        {
            Debug.Log("Game Over!");
        }
        else
        {
            DisplayLives();
        }
    }

    public static void DisplayLives()
    {
        Debug.Log("Lives: " + lives);
    }
}
