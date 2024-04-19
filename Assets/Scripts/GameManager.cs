using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player; // Player GameObject

    void Start()
    {
        director.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || director.state != PlayState.Playing)
        {
            director.Stop();
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        foreach (Transform child in player.transform)
        {
            if (child.CompareTag("MainCamera"))
            {
                child.gameObject.SetActive(true); // Enable Player Camera
            }
        }

        // Enable Player Control
        player.GetComponent<PlayerController>().enabled = true;
    }
}
