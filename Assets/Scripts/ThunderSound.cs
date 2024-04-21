using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] thunder;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) == 0)
        {
            source.clip = thunder[Random.Range(0, thunder.Length)];
            source.Play();

        }
    }
}
