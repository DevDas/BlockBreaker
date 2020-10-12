using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int BreakableBlocks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        BreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        --BreakableBlocks;

        if (BreakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
