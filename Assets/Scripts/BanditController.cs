using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private GameObject bandit;
    [SerializeField]
    private GameObject blood;
    Animator animController;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            audio.PlayOneShot(audio.clip, .7f);
            Instantiate(blood, other.transform.position, other.transform.rotation);
            animController.SetInteger("Chance", Random.Range(0, 2));
            animController.SetTrigger("Die");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animController = bandit.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
