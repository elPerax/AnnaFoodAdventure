using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class HistoryManager : MonoBehaviour
{
    public TextMeshProUGUI scoresListText;

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            var sorted = ScoreManager.instance.savedScores
                .OrderByDescending(s => s.score)
                .ToList();

            string display = "";

            foreach (var s in sorted)
            {
                display += $"{s.name}: {s.score}\n";
            }

            scoresListText.text = display;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
