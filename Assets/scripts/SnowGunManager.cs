using UnityEngine;

public class SnowGunManager : MonoBehaviour
{
    public SnowGun gun1;
    public SnowGun gun2;

    private float timer = 0f;
    private float switchTime = 20f;
    private bool gun1Active = true;

    void Start()
    {
        Debug.Log("SnowGunManager STARTED.");
        gun1.StartFiring();
        gun2.StopFiring();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            timer = 0f;
            gun1Active = !gun1Active;

            if (gun1Active)
            {
                Debug.Log("Switching to Gun 1");
                gun1.StartFiring();
                gun2.StopFiring();
            }
            else
            {
                Debug.Log("Switching to Gun 2");
                gun2.StartFiring();
                gun1.StopFiring();
            }
        }
    }
}
