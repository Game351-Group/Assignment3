using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    [Header("----------- Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource envSource;

    [Header("----------- Audio Clip --------------")]
    public AudioClip mainBackground;
    public AudioClip suspenseBackground;
    public AudioClip fightBackground;
    public AudioClip subtleWind;
    public AudioClip footSteps;
    public AudioClip gunShot;
    public AudioClip explosion;
    public AudioClip banditDeath;

    public void Start()
    {
        musicSource.clip = mainBackground;
        musicSource.Play();
        envSource.clip = subtleWind;
        envSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
