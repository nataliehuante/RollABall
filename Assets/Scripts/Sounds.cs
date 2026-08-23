using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip MainMenuSound;
    public AudioClip InGameSound;
    public AudioClip ButtonClickSound;
    public AudioClip LevelPassSound;
    public AudioClip GameWonSound;
    public AudioClip GameLostSound;
    public AudioClip PlayerHitWallSound;
    public AudioClip PlayerLoseLifeSound;
    public AudioClip PlayerCollectPickUpSound;
    public static Sounds Instance;

    public AudioSource sfxAudioSource;
    public AudioSource mainMenuAudioSource;
    public AudioSource inGameAudioSource;

    private void Awake()
    {
        if (Instance != null & Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    void Start()
    {
        sfxAudioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayMainMenu()
    {
        mainMenuAudioSource.Play();
    }

    public void PauseMainMenu()
    {
        mainMenuAudioSource.Pause();
    }

    public void PlayInGame()
    {
        inGameAudioSource.Play();
    }

    public void PauseInGame()
    {
        inGameAudioSource.Pause();
    }

    public void PlayButtonClick()
    {
        sfxAudioSource.PlayOneShot(ButtonClickSound, 0.7f);
    }

    public void PlayLevelPass()
    {
        sfxAudioSource.PlayOneShot(LevelPassSound);
    }

    public void PlayGameWon()
    {
        sfxAudioSource.PlayOneShot(GameWonSound);
    }

    public void PlayGameLost()
    {
        sfxAudioSource.PlayOneShot(GameLostSound);
    }

    public void PlayWallHit()
    {
        sfxAudioSource.PlayOneShot(PlayerHitWallSound, 0.7f);
    }

    public void PlayLoseLife()
    {
        sfxAudioSource.PlayOneShot(PlayerLoseLifeSound, 0.7f);
    }

    public void PlayCollectPickUp()
    {
        sfxAudioSource.PlayOneShot(PlayerCollectPickUpSound);
    }
    
    
}
