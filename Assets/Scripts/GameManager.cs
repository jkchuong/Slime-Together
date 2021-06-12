using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private AudioClip winClip;
    
    private AudioSource audioSource;
    
    public int numberOfGoals;
    private int numberOfGoalsReached;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnterGoal()
    {
        numberOfGoalsReached += 1;

        if (numberOfGoals == numberOfGoalsReached)
        {
            audioSource.PlayOneShot(winClip);
            
            PlayerController[] players = FindObjectsOfType<PlayerController>();

            foreach (var player in players)
            {
                player.Pause();
            }

            winCanvas.SetActive(true);

            int currentScene = SceneManager.GetActiveScene().buildIndex;

            if (currentScene + 1 <= SceneManager.sceneCountInBuildSettings && LevelTrack.Instance != null)
            {
                LevelTrack.Instance.AddUnlockedLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void ExitGoal()
    {
        numberOfGoalsReached -= 1;
    }
}