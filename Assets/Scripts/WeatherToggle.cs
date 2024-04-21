using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject lighting;
    [SerializeField]
    private GameObject sunnyWeather;
    [SerializeField]
    private GameObject stormyWeather;
    private bool isSunny = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isSunny == true)
            {
                lighting.transform.rotation = Quaternion.Euler(-177.603f, -702.168f, 92.812f);
                Instantiate(stormyWeather, transform.position, transform.rotation);
                Destroy(GameObject.Find("Sky(Clone)"));
                isSunny = false;
            }
            else
            {
                lighting.transform.rotation = Quaternion.Euler(45.358f, -149.227f, 65.37f);
                Destroy(GameObject.Find("Monsoon(Clone)"));
                Instantiate(sunnyWeather, transform.position, transform.rotation);
                isSunny = true;
            }
        }   
    }
}
