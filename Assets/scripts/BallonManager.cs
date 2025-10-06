using UnityEngine;
using System.Collections;

public class BalloonManager : MonoBehaviour
{
    public GameObject balloonTop;
    public GameObject balloonBottom;
    public GameObject balloonLeft;
    public GameObject balloonRight;
    public GameObject blackBalloonPrefab;

    private int spawnCount = 0;  // Tracks how many balloons we've spawned

    void Start()
    {
        SpawnBalloon("BallonTop");
        SpawnBalloon("BalloonBottom");
        SpawnBalloon("BalloonLeft");
        SpawnBalloon("BalloonRight");
    }

    public void BalloonPopped(string tag)
    {
        StartCoroutine(RespawnBalloon(tag));
    }

    IEnumerator RespawnBalloon(string tag)
    {
        yield return new WaitForSeconds(2f);
        SpawnBalloon(tag);
    }

    void SpawnBalloon(string tag)
    {
        GameObject prefabToSpawn = null;
        Vector2 pos = Vector2.zero;

        // Set the position based on tag
        switch (tag)
        {
            case "BallonTop":
                pos = new Vector2(Random.Range(-8f, 8f), 3.5f);
                break;
            case "BalloonBottom":
                pos = new Vector2(Random.Range(-8f, 8f), -3.52f);
                break;
            case "BalloonLeft":
                pos = new Vector2(-10.15f, Random.Range(-3f, 3f));
                break;
            case "BalloonRight":
                pos = new Vector2(10.18f, Random.Range(-3f, 3f));
                break;
        }

        // Every 6th balloon should be black
        bool spawnBlack = spawnCount % 6 == 5;
        spawnCount++;

        if (spawnBlack)
        {
            prefabToSpawn = blackBalloonPrefab;
        }
        else
        {
            switch (tag)
            {
                case "BallonTop": prefabToSpawn = balloonTop; break;
                case "BalloonBottom": prefabToSpawn = balloonBottom; break;
                case "BalloonLeft": prefabToSpawn = balloonLeft; break;
                case "BalloonRight": prefabToSpawn = balloonRight; break;
            }
        }

        if (prefabToSpawn != null)
        {
            GameObject newBalloon = Instantiate(prefabToSpawn, pos, Quaternion.identity);
            newBalloon.tag = spawnBlack ? "BlackBalloon" : tag;
            Debug.Log("Spawned " + newBalloon.tag + " at " + pos);
        }
    }
}
