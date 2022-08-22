using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Blinking_light : MonoBehaviour
{
    public Light2D light2D; 

    // Start is called before the first frame update
    void Start()
    {
        light2D = gameObject.GetComponent<Light2D>();

        StartCoroutine(lightFlicking());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void lightFlick()
    {
        light2D.intensity = Random.Range(0.0f, 1.0f);
    }

    IEnumerator lightFlicking()
    {
        while (true)
        {
            lightFlick();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
