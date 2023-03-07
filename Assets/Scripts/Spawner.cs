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

                Instantiate(enemyPrefab, new Vector3(spawn.x - (spawn.x * col * 0.12f), spawn.y - spawn.y * row * 0.25f, 0), Quaternion.identity);
            }
        }
    }
}
