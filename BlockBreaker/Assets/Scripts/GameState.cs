using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float GameSpeed = 1f;

    [SerializeField] int CurrentScore = 0;
    [SerializeField] int PointsPerBlockDestroyed = 20;

    TextMeshProUGUI ScoreText;

    void Start()
    {
        ScoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        Time.timeScale = GameSpeed;
        ScoreText.text = CurrentScore.ToString();
    }

    public void AddToScore()
    {
        CurrentScore += PointsPerBlockDestroyed;
    }
}
