using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds { GameOver, StartGame, Respawn}

public class SoundController : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip gameOverClip;
    public AudioClip startGameClip;
    public AudioClip respawnClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.GameOver:
                PlaySound(gameOverClip);
                break;
            case Sounds.StartGame:
                PlaySound(startGameClip);
                break;
            case Sounds.Respawn:
                PlaySound(respawnClip);
                break;
        }
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }


}
