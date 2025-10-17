using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("=========== Audio Source =========== ")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("============ Audio Clips ============ ")]
    public AudioClip background;
    public AudioClip gameOver;
    public AudioClip gameWon;
    public AudioClip keyCollected;
    public AudioClip gameStart;

    private void Awake()
    {
        // Prevent scene reload duplicates 
        if (FindObjectsOfType<AudioController>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        // Persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Start background music if you have one
        if (background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true; // Make it loop
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }
}