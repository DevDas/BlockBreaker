using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BreakSound;

    // Cached Reference
    Level LevelObject;
    GameState GS;

    [SerializeField] GameObject BlockVFX;
    [SerializeField] int MaxHits;
    [SerializeField] int TimesHit;

    [SerializeField] Sprite Broke1;
    [SerializeField] Sprite Broke2;

    private void Start()
    {
        LevelObject = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            LevelObject.CountBreakableBlocks();
        }

        GS = FindObjectOfType<GameState>();
    }

    private void TriggerVFX()
    {
        GameObject Spark = Instantiate(BlockVFX, transform.position, transform.rotation);
        Destroy(Spark, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);

        if (tag == "UnBreakable") return;

        TimesHit++;

        if (TimesHit >= 1)
        {
            GetComponent<SpriteRenderer>().sprite = Broke1;
        }

        if (TimesHit >= 2)
        {
            GetComponent<SpriteRenderer>().sprite = Broke2;
        }

        if (TimesHit >= MaxHits)
        {
            LevelObject.BlockDestroyed();
            
            TriggerVFX();

            Destroy(gameObject);
        }

        GS.AddToScore();
    }
}
