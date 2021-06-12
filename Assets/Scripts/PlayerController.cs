using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    // Cache
    private Rigidbody2D playerRigidbody2D;

    private bool isGrounded;
    
    private bool paused;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (paused) return;
        Run();
        Jump();
        // FlipSprite();
    }

    private void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            var localScale = transform.localScale;
            localScale = new Vector2(Mathf.Sign(playerRigidbody2D.velocity.x) * localScale.x, localScale.y);
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        if (!Input.GetButtonDown("Jump") || !isGrounded) return;
        Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
        playerRigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
    
    private void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(horizontalInput * runSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = runVelocity;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Pause()
    {
        paused = true;
    }
}
