using UnityEngine;

public class SnowyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float rotationSpeed = 180f;

    [Header("Effects")]
    public GameObject splashEffectPrefab;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.jumpSFX);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    return;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform")) && splashEffectPrefab != null)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.PlaySFX(AudioManager.instance.splashSFX);
                    }

                    Vector3 splashPos = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                    Instantiate(splashEffectPrefab, splashPos, Quaternion.identity);
                    break;
                }
            }
        }
    }
}
