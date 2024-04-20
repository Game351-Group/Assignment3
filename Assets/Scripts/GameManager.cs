using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI; // UI 요소를 사용하기 위해 추가

public class GameManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    public GameObject sheriff;
    public Image fadeImage;

    private Vector3 playerStartPosition = new Vector3(3.35f, 0.069f, 8.84f);
    private Quaternion playerStartRotation = Quaternion.Euler(0, 145.248f, 0);
    private Vector3 sheriffStartPosition = new Vector3(4.47f, 0f, 2.88f);
    private Quaternion sheriffStartRotation = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        // Start with fade out
        StartCoroutine(Fade(0));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FadeInOut());
        }
    }

    IEnumerator Fade(float targetAlpha)
    {
        float fadeSpeed = 1f;
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
        yield return new WaitForSeconds(3); // Wait for 3 secs
        yield return StartCoroutine(Fade(0)); // Fade out
        GetComponent<GameManager>().enabled = false;
    }

    void EndCutscene()
    {
        // Set the position to the spawnpoint
        player.transform.position = playerStartPosition;
        player.transform.rotation = playerStartRotation;

        sheriff.transform.localPosition = sheriffStartPosition;
        sheriff.transform.localRotation = sheriffStartRotation;

        foreach (Transform child in player.transform)
        {
            if (child.CompareTag("MainCamera"))
            {
                child.gameObject.SetActive(true);
            }
        }
        player.GetComponent<PlayerController>().enabled = true;
    }
}
