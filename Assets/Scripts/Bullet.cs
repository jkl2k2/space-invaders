using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    public bool isEnemy;
    
    private Rigidbody2D myRigidbody2D;

    public float speed = 10;
  
    void Start()
    { 
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }
    
    private void Fire()
    {
        if (isEnemy)
        {
            myRigidbody2D.velocity = Vector2.down * speed; 
        }
        else
        {
            myRigidbody2D.velocity = Vector2.up * speed; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (isEnemy && !collider2D.gameObject.tag.Equals("Player") && !collider2D.gameObject.tag.Equals("Catch") && !collider2D.gameObject.tag.Equals("Barrier"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
