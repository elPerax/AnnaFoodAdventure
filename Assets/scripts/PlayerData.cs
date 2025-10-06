using UnityEngine;
using System.Collections.Generic;

public static class PlayerData
{
    public static string playerName = "Guest";
    public static int playerScore = 0;

    public static void SaveScore()
    {
        string entry = playerName + " - " + playerScore;
        List<string> history = LoadScores();
        history.Add(entry);
        string joined = string.Join("|", history);
        PlayerPrefs.SetString("ScoreHistory", joined);
        PlayerPrefs.Save();
    }

    public static List<string> LoadScores()
    {
        string raw = PlayerPrefs.GetString("ScoreHistory", "");
        List<string> history = new List<string>();
        if (!string.IsNullOrEmpty(raw))
        {
            history = new List<string>(raw.Split('|'));
        }
        return history;
    }
}
