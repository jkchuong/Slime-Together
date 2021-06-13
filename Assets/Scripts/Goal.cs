using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Sprite flagDown;
    public Sprite flagUp;

    public ColourEnum goalColour;

    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gameManager.numberOfGoals += 1;
        ChangeSprite(flagDown);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player && player.playerColour == goalColour && !player.Paused()) 
        {
            gameManager.EnterGoal();
            ChangeSprite(flagUp);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player && player.playerColour == goalColour && !player.Paused())
        {
            gameManager.ExitGoal();
            ChangeSprite(flagDown);
        }
    }
    
    public void ChangeSprite(Sprite flagState)
    {
        spriteRenderer.sprite = flagState;
    }
}