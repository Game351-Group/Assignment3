using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspTigger : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource suspSource;
    public AudioClip SuspMusic;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !suspSource.isPlaying)
        {
            musicSource.Pause();
            suspSource.clip = SuspMusic;
            suspSource.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        suspSource.Pause();
        musicSource.Play();
    }
}
