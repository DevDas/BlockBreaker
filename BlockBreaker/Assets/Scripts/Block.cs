using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BreakSound;

    // Cached Reference
    Level LevelObject;
    GameState GS;

    [SerializeField] GameObject BlockVFX;
    [SerializeField] int TimesHit;

    [SerializeField] Sprite[] BrokeSprites;

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
        int MaxHits = BrokeSprites.Length + 1;

        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);

        if (tag == "UnBreakable") return;

        TimesHit++;

        if (TimesHit >= MaxHits)
        {
            LevelObject.BlockDestroyed();
            
            TriggerVFX();

            Destroy(gameObject);
        }
        else
        {
            ShowNextHitSprites();
        }

        GS.AddToScore();
    }

    private void ShowNextHitSprites()
    {
        int BrokeSpriteIndex = TimesHit - 1;
        if (BrokeSprites[BrokeSpriteIndex] == null) return;
        GetComponent<SpriteRenderer>().sprite = BrokeSprites[BrokeSpriteIndex];
    }
}
