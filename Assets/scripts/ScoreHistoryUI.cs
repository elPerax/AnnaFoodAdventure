using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreHistoryUI : MonoBehaviour
{
    public TextMeshProUGUI historyText;

    void Start()
    {
        DisplayHistory();
    }

    void DisplayHistory()
    {
        List<string> history = PlayerData.LoadScores();
        history.Sort((a, b) => int.Parse(b.Split('-')[1]).CompareTo(int.Parse(a.Split('-')[1]))); 

        historyText.text = "Score History:\n";
        foreach (string entry in history)
        {
            historyText.text += entry + "\n";
        }
    }
}
