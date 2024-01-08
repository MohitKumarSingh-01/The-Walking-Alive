using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float dayLength = 0.5f;
    public float nightLength = 1f;
    public float time = 1f;
    public float hour = 24f;
    public Light sun;
   
    public Material dayMaterial;


    private void Update()
    {
        sun.transform.Rotate(Time.deltaTime / time, 0, 0);
        hour += Time.deltaTime / time;

        if(hour >= 360)
        {
            hour = 0f;
            sun.enabled = true;
        }
       
        if (hour >= 200)
        {
            time = nightLength;
            sun.enabled = false;
            sun.intensity -= Time.deltaTime;
        }
        if (hour <= 300)
        {
            time = dayLength;
            sun.intensity += Time.deltaTime;
            RenderSettings.sun = sun;
    
        }

        if (sun.intensity >= 1f)
        {
            sun.intensity = 1f;
        }
        if (sun.intensity <= 0.1f)
        {
            sun.intensity = 0.1f;
        }
    }
}