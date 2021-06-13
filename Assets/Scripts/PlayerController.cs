using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private AudioClip[] jumpSounds;

    public ColourEnum playerColour;
    
    // Cache
    private Rigidbody2D playerRigidbody2D;
    private AudioSource audioSource;
    
    private bool isGrounded;
    
    private bool paused;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (paused) return;
        Run();
        Jump();
    }

    private void Jump()
    {
        if (!Input.GetButtonDown("Jump") || !isGrounded) return;
        Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
        playerRigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
        isGrounded = false;
        audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
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

    public bool Paused() => paused;
}
