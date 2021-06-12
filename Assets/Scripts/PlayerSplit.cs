using UnityEngine;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] private GameObject smallPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D originalRb = GetComponent<Rigidbody2D>();
        
        if (other.CompareTag("Spike"))
        {
            other.gameObject.SetActive(false);
            foreach (Transform child in other.transform)
            {
                GameObject newPlayer = Instantiate(smallPlayer, child.position, gameObject.transform.rotation);
                Rigidbody2D newRb = newPlayer.GetComponent<Rigidbody2D>();

                newRb.velocity = originalRb.velocity;

            }
            
            Destroy(gameObject);
        }
    }
}
