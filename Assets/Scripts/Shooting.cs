using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    float NextFire;
    [SerializeField]
    private float FireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
