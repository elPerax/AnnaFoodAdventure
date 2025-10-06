using UnityEngine;

public class BalloonRespawner : MonoBehaviour
{
    private PlatformBalloonSpawner spawner;
    private Transform platform;

    public void Initialize(PlatformBalloonSpawner spawnerRef, Transform platformRef)
    {
        spawner = spawnerRef;
        platform = platformRef;
    }

    void OnDestroy()
    {
        if (spawner != null && platform != null)
        {
            spawner.RespawnBalloon(platform);
        }
    }
}
