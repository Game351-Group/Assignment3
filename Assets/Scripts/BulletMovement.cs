using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    private float delay = 5;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed*Time.deltaTime);
    }
}
