using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonList : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;

    private void Start()
    {
        foreach (int level in LevelTrack.Instance.unlockedLevels)
        {
            buttonList[level - 1].interactable = true;
        }
    }

    public int NumberOfLevelButtons()
    {
        return buttonList.Count;
    }
}
