using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformBalloonSpawner : MonoBehaviour
{
    public GameObject yellowBalloonPrefab;
    public int balloonsPerPlatform = 1;
    public float respawnDelay = 3f;

    private List<Transform> platforms = new List<Transform>();

    void Start()
    {
        Debug.Log("PlatformBalloonSpawner active and spawning.");

        GameObject[] platformObjects = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject obj in platformObjects)
        {
            Collider2D col = obj.GetComponent<Collider2D>();
            if (col != null)
            {
                platforms.Add(obj.transform);
            }
            else
            {
                Debug.LogWarning($"Platform '{obj.name}' is missing a Collider2D and will be skipped.");
            }
        }

        SpawnAllBalloons();
    }

    void SpawnAllBalloons()
    {
        foreach (Transform platform in platforms)
        {
            for (int i = 0; i < balloonsPerPlatform; i++)
            {
                SpawnBalloonOnPlatform(platform);
            }
        }
    }

    void SpawnBalloonOnPlatform(Transform platform)
    {
        Collider2D col = platform.GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogWarning("Tried to spawn a balloon on a platform without a Collider2D.");
            return;
        }

        Bounds bounds = col.bounds;
        float xPos = Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f);
        float yPos = bounds.max.y + 0.5f;

        GameObject balloon = Instantiate(yellowBalloonPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        balloon.tag = "Balloon";

        BalloonRespawner respawner = balloon.GetComponent<BalloonRespawner>();
        if (respawner == null)
        {
            respawner = balloon.AddComponent<BalloonRespawner>();
        }

        respawner.Initialize(this, platform);
    }

    public void RespawnBalloon(Transform platform)
    {
        StartCoroutine(RespawnAfterDelay(platform));
    }

    private IEnumerator RespawnAfterDelay(Transform platform)
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnBalloonOnPlatform(platform);
    }
}
