using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static AudioManager Instance
    {
        get;
        set;
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

        audioSource = GetComponent<AudioSource>();
    }
}
