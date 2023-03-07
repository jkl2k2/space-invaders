using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int value;

    private TextMeshProUGUI score;
    private TextMeshProUGUI highScore;

    private void Start()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");

        score = canvas.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        highScore = canvas.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.tag.Equals("PlayerBullet")) return;
        
        string scoreString = "";
        int newScore = int.Parse(score.text) + value;
        int currentHighScore = int.Parse(highScore.text);
        
        if (newScore < 100)
        {
            scoreString += "00";
        } else if (newScore < 1000)
        {
            scoreString += "0";
        }
        
        scoreString += newScore;
        
        score.SetText(scoreString);
        
        if (newScore > currentHighScore)
        {
            highScore.SetText(scoreString);
            PlayerPrefs.SetInt("highScore", newScore);
        }
        
        gameObject.SetActive(false);
    }
}
