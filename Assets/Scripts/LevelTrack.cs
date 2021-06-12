using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTrack : MonoBehaviour
{
    [SerializeField] private int numberOfLevels;
    public List<int> unlockedLevels;

    public static LevelTrack Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        unlockedLevels = new List<int>();
    }

    private void Start()
    {
        numberOfLevels = FindObjectOfType<ButtonList>().NumberOfLevelButtons();
        unlockedLevels.Add(1);
    }

    public void AddUnlockedLevel(int level)
    {
        if (unlockedLevels.Contains(level) || unlockedLevels.Count + 1 > numberOfLevels) return;
        unlockedLevels.Add(level);
    }
}
