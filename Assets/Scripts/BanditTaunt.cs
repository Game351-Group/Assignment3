using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditTaunt : MonoBehaviour
{
    public AudioSource banditTauntSource;
    public AudioClip[] banditAudioClips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayPauseCoroutine());
    }

    IEnumerator PlayPauseCoroutine()
    {
        while (true)
        {
            float interval = Random.Range(10f, 30f);
            yield return new WaitForSeconds(interval);

            AudioClip randomClip = banditAudioClips[Random.Range(0, banditAudioClips.Length)];
            banditTauntSource.PlayOneShot(randomClip);
        }
    }
}