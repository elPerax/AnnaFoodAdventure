using UnityEngine;
using UnityEngine.SceneManagement;

public class Snowball : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 4f;

    private Vector2 moveDirection;

    void Start()
    {
        float angle = 0f;

        if (transform.position.x < 0)
        {
            angle = Random.Range(250f, 315f);
        }
        else
        {
            angle = Random.Range(195f, 270f);
        }

        float radians = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Purly Died!");

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.SaveCurrentScore();
            }

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.gameOverSFX);
            }

            SceneManager.LoadScene("StartMenu");

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
