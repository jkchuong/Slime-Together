using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private AudioClip winClip;
    
    private AudioSource audioSource;
    
    public int numberOfGoals;
    private int numberOfGoalsReached;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }

    public void EnterGoal()
    {
        numberOfGoalsReached += 1;

        if (numberOfGoals == numberOfGoalsReached)
        {
            audioSource.PlayOneShot(winClip);
            
            winCanvas.SetActive(true);

            RaiseAllGoals();
            
            PausePlayers();

            UnlockNextLevel();
        }
    }

    private static void RaiseAllGoals()
    {
        Goal[] goals = FindObjectsOfType<Goal>();
        foreach (Goal goal in goals)
        {
            goal.ChangeSprite(goal.flagUp);
        }
    }

    private static void UnlockNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene + 1 <= SceneManager.sceneCountInBuildSettings && LevelTrack.Instance != null)
        {
            LevelTrack.Instance.AddUnlockedLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private static void PausePlayers()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();

        foreach (var player in players)
        {
            player.Pause();
        }
    }

    public void ExitGoal()
    {
        numberOfGoalsReached -= 1;
    }
}