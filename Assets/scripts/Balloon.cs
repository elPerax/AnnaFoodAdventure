using UnityEngine;

public class Balloon : MonoBehaviour
{
    private string originalTag;

    [Header("Pop Effects")]
    public GameObject yellowPopEffect;
    public GameObject blackPopEffect;

    void Start()
    {
        // Save the original tag when the balloon spawns
        originalTag = gameObject.tag;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 spawnPos = transform.position;

            if (CompareTag("BlackBalloon"))
            {
                Debug.Log("Hit black balloon!");
                ScoreManager.instance.score -= 3;
                AudioManager.instance.PlaySFX(AudioManager.instance.blackBalloonSFX);

                if (blackPopEffect != null)
                    Instantiate(blackPopEffect, spawnPos, Quaternion.identity);
            }
            else
            {
                Debug.Log("Hit yellow balloon!");
                ScoreManager.instance.AddPoint();
                AudioManager.instance.PlaySFX(AudioManager.instance.yellowBalloonSFX);

                if (yellowPopEffect != null)
                    Instantiate(yellowPopEffect, spawnPos, Quaternion.identity);
            }

            ScoreManager.instance.UpdateScoreUI();
            FindObjectOfType<BalloonManager>().BalloonPopped(originalTag);
            Destroy(gameObject);
        }
    }
}
