using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public Transform shootingOffset;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        }
    }
    
    private void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis("Horizontal");

        if (horizontalValue > 0)
        {
            transform.Translate(0.2f, 0f, 0f);
        } else if (horizontalValue < 0)
        {
            transform.Translate(-0.2f, 0f, 0f);
        }
    }
}
