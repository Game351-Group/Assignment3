using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private GameObject debris;
    [SerializeField]
    private GameObject explosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(debris, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
