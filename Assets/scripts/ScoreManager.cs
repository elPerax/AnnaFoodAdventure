using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public string playerName;
    public List<PlayerScore> savedScores = new List<PlayerScore>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Aura Points: " + score;
    }

    public void SaveCurrentScore()
    {
        PlayerData.playerScore = score;
        PlayerData.SaveScore();
        Debug.Log("Saved: " + PlayerData.playerName + " | Score: " + score);
    }
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;

    public PlayerScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
