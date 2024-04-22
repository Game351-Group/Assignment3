using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource envSource;
    public AudioSource otherMusic;

    public AudioClip mainBackground;
    public AudioClip fightBackground;
    public AudioClip subtleWind;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = mainBackground;
        musicSource.Play();
        envSource.clip = subtleWind;
        envSource.Play();
        StartCoroutine("PlayPauseCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !otherMusic.isPlaying)
        {
            musicSource.Pause();
            otherMusic.clip = fightBackground;
            StartCoroutine(PlayPauseCoroutine());
        }
    }

    IEnumerator PlayPauseCoroutine()
    {
        while (!musicSource.isPlaying)
        {
            otherMusic.Play();
            yield return new WaitForSeconds(20);
            otherMusic.Pause();
            if (!otherMusic.isPlaying)
            {
                musicSource.Play();
            }
        }
        
    }
}
