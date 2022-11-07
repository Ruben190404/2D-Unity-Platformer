using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public static int lives = 3;
    
    
    
    [SerializeField] private Text livesText;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        livesText.text = "Lives left: " + lives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            lives -= 1;
            ItemCollector.removeScore += 600;
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        if (lives < 0)
        {
            //load scene by name
            SceneManager.LoadScene("Game Over Scene");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "DeathZone")
        {
            Die();
            lives -= 1;
            ItemCollector.removeScore += 600;
        }
    }
    
}
