using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ColourEnum goalColour;
    
    private GameManager gameManager;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        gameManager.numberOfGoals += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player && player.playerColour == goalColour)
        {
            gameManager.EnterGoal();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player && player.playerColour == goalColour)
        {
            gameManager.ExitGoal();
        }
    }
}