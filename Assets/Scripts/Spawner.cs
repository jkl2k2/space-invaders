using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject enemyBulletPrefab;

    private const int numRows = 5;
    private const int numCols = 11;

    private Vector3 direction = Vector3.right;
    private float speed = 1f;

    private int numKilled;

    private float attackRate = 1f;
    
    public TextMeshProUGUI highScore;

    private void Awake()
    {
        highScore.SetText(PlayerPrefs.GetInt("highScore").ToString());
        
        string scoreString = "";
        int highScoreSaved = PlayerPrefs.GetInt("highScore");

        if (highScoreSaved < 10)
        {
            scoreString += "000";
        } else if (highScoreSaved < 100)
        {
            scoreString += "00";
        } else if (highScoreSaved < 1000)
        {
            scoreString += "0";
        }

        scoreString += highScoreSaved;
        
        highScore.SetText(scoreString);
    }
    
    private void Start()
    {
        InvokeRepeating(nameof(Attack), attackRate, attackRate);
        
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector3 spawn = transform.position;
                const float xMultiplier = 0.8f;
                const float yMultiplier = 0.8f;

                Instantiate(enemyPrefab[row], new Vector3((spawn.x - col * xMultiplier) + 5, spawn.y - row * yMultiplier, 0), Quaternion.identity, transform);
            }
        }
    }

    private void Update()
    {
        int killCount = 0;
        
        transform.position += direction * (speed * Time.deltaTime);

        const float leftBoundary = -9f;
        const float rightBoundary = 9f;
        
        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                killCount++;
                continue;
            }
            
            if (direction == Vector3.right && enemy.position.x >= rightBoundary - 1f)
            {
                HandleMovement();
            } else if (direction == Vector3.left && enemy.position.x <= leftBoundary + 1f)
            {
                HandleMovement();
            }
        }

        numKilled = killCount;

        float fracKilled = (float) numKilled / (numRows * numCols);
        
        if (fracKilled > 0.9)
        {
            speed = 6;
        } else if (fracKilled > 0.75)
        {
            speed = 4;
        } else if (fracKilled > 0.5)
        {
            speed = 3;
        } else if (fracKilled > 0.25)
        {
            speed = 2;
        }
        else if (fracKilled > 0.15)
        {
            speed = 1.5f;
        }
        else
        {
            speed = 1;
        }
    }

    private void HandleMovement()
    {
        // Flip direction
        direction.x = -direction.x;
        
        // Move down one
        transform.Translate(0f, -0.5f, 0f);
    }

    private void Attack()
    {
        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy) continue;

            float rand = Random.value;

            if (rand < 1.0f / (numRows * numCols - numKilled))
            {
                Instantiate(enemyBulletPrefab, enemy.GetChild(0).position, Quaternion.identity);
                break;
            }
        }
    }
}
