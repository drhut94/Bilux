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
    float hue;
        float timeLeft;
        Color targetColor;

    private void Start()
    {
        timerBackup = timer;
        hue = 1;
    }

    void Update()
    {


            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                color = targetColor;

                // start a new transition
                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 3.0f;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                color = Color.Lerp(color, targetColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        
        RenderSettings.skybox.SetColor("_Tint", color);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}


