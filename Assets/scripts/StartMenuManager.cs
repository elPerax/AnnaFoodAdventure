using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject historyPanel;

    void Start()
    {
        // Play start menu music
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.music1);
        }
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            PlayerData.playerName = nameInputField.text;
        }

        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHistoryPanel()
    {
        historyPanel.SetActive(true);
    }
}
