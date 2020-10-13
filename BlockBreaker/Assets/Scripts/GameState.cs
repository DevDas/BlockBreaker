using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float GameSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Time.timeScale = GameSpeed;
    }
}
