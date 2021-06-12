using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCombine : MonoBehaviour
{
    [SerializeField] private GameObject bigPlayer;

    public float value;
    
    private void Awake()
    {
        value = Random.Range(0f, 100f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerCombine otherPlayer = other.gameObject.GetComponent<PlayerCombine>();
        if (otherPlayer && value > otherPlayer.value)
        {
            Vector3 centralPosition = (other.transform.position + transform.position) / 2;

            GameObject newPlayer = Instantiate(bigPlayer, centralPosition, Quaternion.identity);
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
