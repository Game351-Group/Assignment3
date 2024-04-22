using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    public GameObject sheriff;
    public Image fadeImage;
    public List<Transform> bandits;

    private Vector3 playerStartPosition = new Vector3(3.35f, 0.069f, 8.84f);
    private Quaternion playerStartRotation = Quaternion.Euler(0, 145.248f, 0);
    private Vector3 sheriffStartPosition = new Vector3(4.47f, 0f, 2.88f);
    private Quaternion sheriffStartRotation = Quaternion.Euler(0, 0, 0);
    private Dictionary<Transform, Vector3> initialPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> initialRotations = new Dictionary<Transform, Quaternion>();

    void Start()
    {
        // Save initial positions and rotations of other characters
        foreach (Transform character in bandits)
        {
            initialPositions[character] = character.position;
            initialRotations[character] = character.rotation;
        }

        // Start with fade out
        StartCoroutine(Fade(0));
    }

    void Update()
    {
        // If director is playing and the time remaining is less than 2 seconds, start fade out
        if (director.state == PlayState.Playing && director.duration - director.time <= 2f)
        {
            StartCoroutine(FadeInOut());
            enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FadeInOut());
            enabled = false;
        }
    }

    IEnumerator Fade(float targetAlpha)
    {
        float fadeSpeed = 0.5f;
        while (!Mathf.Approximately(fadeImage.color.a, targetAlpha))
        {
            float newAlpha = Mathf.MoveTowards(fadeImage.color.a, targetAlpha, Time.deltaTime * fadeSpeed);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }
    }

    IEnumerator FadeInOut()
    {
        yield return StartCoroutine(Fade(1)); // Fade In
        EndCutscene();
        director.Stop();
        yield return new WaitForSeconds(2); // Wait for 2 secs
        yield return StartCoroutine(Fade(0)); // Fade out
    }

    void EndCutscene()
    {
        // Set the position to the spawnpoint for main characters
        player.transform.position = playerStartPosition;
        player.transform.rotation = playerStartRotation;

        sheriff.transform.localPosition = sheriffStartPosition;
        sheriff.transform.localRotation = sheriffStartRotation;

        // Reset positions and rotations of other characters
        foreach (Transform character in bandits)
        {
            character.position = initialPositions[character];
            character.rotation = initialRotations[character];
        }

        foreach (Transform child in player.transform)
        {
            if (child.CompareTag("MainCamera"))
            {
                child.gameObject.SetActive(true);
            }
        }
        DisableCutsceneObjects();
        player.GetComponent<PlayerController>().enabled = true;
    }

    void DisableCutsceneObjects()
    {
        GameObject[] cutsceneObjects = GameObject.FindGameObjectsWithTag("CutScene");
        foreach (GameObject obj in cutsceneObjects)
        {
            obj.SetActive(false);
        }
    }
}
