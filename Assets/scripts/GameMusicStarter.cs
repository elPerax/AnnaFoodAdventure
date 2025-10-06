using UnityEngine;

public class GameMusicStarter : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.music2);
        }
    }
}
