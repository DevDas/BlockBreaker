using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BreakSound;

    // Cached Reference
    Level LevelObject;
    SceneLoader sceneLoader;

    private void Start()
    {
        LevelObject = FindObjectOfType<Level>();
        LevelObject.CountBreakableBlocks();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);

        --LevelObject.BreakableBlocks;

        if (LevelObject.BreakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }

        Destroy(gameObject);
    }
}
