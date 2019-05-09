using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public float timer;
    public float rotationSpeed;

    float timerBackup;
    Color color;
    int hue;

    private void Start()
    {
        timerBackup = timer;
        hue = 1;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = timerBackup;
            hue++;
            Debug.Log(hue);
            if (hue >= 360)
            {
                hue = 1;
            }

            color = Color.HSVToRGB(hue, 60, 100);
            RenderSettings.skybox.SetColor("_Tint", new Color(color.r, color.g, color.b));
        }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}


