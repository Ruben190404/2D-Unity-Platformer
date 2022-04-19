using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int cherries = 0;
    public static int cherryValue = 50;
    public static int pineapples = 0;
    public static int pineappleValue = 200;
    public static int removeScore = 0;

    [SerializeField] private Text ScoreText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        int score = (cherries * cherryValue + pineapples * pineappleValue - removeScore);
        
        ScoreText.text = "Score: " + score;
        if (score < 0)
        {
            ScoreText.text = "Score: 0";
            removeScore = (cherries * cherryValue + pineapples * pineappleValue);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
        }

        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            pineapples++;
        }
        int score = (cherries * cherryValue + pineapples * pineappleValue - removeScore);
        
        ScoreText.text = "Score: " + score;
        if (score < 0)
        {
            ScoreText.text = "Score: 0";
            removeScore = (cherries * cherryValue + pineapples * pineappleValue);
        }
    }
}
