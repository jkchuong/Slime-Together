using System;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private Sprite buttonOff;
    [SerializeField] private Sprite buttonOn;

    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private bool stayOnToKeepActive;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectToActivate.SetActive(true);
            spriteRenderer.sprite = buttonOn;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && stayOnToKeepActive)
        {
            objectToActivate.SetActive(false);
            spriteRenderer.sprite = buttonOff;
        }
    }
}
