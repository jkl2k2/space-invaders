using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform shootingOffset;

    private GameObject recentBullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (recentBullet == null || !recentBullet.activeInHierarchy)
            {
                recentBullet = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity);
                GetComponents<AudioSource>()[0].Play();
            }
        }
    }
    
    private void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        
        if (horizontalValue > 0 && transform.position.x < 8.6)
        {
            transform.Translate(0.2f, 0f, 0f);
        } else if (horizontalValue < 0 && transform.position.x > -8.6)
        {
            transform.Translate(-0.2f, 0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.tag.Equals("EnemyBullet")) return;
        
        Debug.Log("You died!");
        
        GetComponents<AudioSource>()[1].Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        GetComponent<ParticleSystem>().Play();

        GameObject.FindWithTag("GameManager").GetComponent<AudioSource>().Stop();
        GameObject.FindWithTag("GameManager").GetComponent<SceneSwitcher>().LoadCreditsScene();
    }
}
