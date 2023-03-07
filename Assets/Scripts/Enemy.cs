using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.tag.Equals("PlayerBullet")) return;
        
        Debug.Log("Ouch!");
        gameObject.SetActive(false);
    }
}
