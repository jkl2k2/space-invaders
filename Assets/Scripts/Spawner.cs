using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private void Start()
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 11; col++)
            {
                Vector3 spawn = transform.position;
                const float xOffset = 0.11f;
                const float yOffset = 0.2f;

                Instantiate(enemyPrefab, new Vector3(spawn.x - (spawn.x * col * xOffset), spawn.y - spawn.y * row * yOffset, 0), Quaternion.identity);
            }
        }
    }
}
