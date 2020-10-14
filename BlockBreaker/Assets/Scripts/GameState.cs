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

    private void Awake()
    {
        int GSCount = FindObjectsOfType<GameState>().Length;
        if (GSCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void ResetGameSession()
    {
        Destroy(gameObject);
    }
}
