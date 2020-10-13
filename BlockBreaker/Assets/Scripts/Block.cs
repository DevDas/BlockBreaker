using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BreakSound;

    // Cached Reference
    Level LevelObject;
    GameState GS;

    private void Start()
    {
        LevelObject = FindObjectOfType<Level>();
        LevelObject.CountBreakableBlocks();
        GS = FindObjectOfType<GameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);

        LevelObject.BlockDestroyed();
        GS.AddToScore();

        Destroy(gameObject);
    }
}
