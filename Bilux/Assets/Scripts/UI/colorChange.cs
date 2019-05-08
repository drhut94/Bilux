using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class colorChange : MonoBehaviour {


    public Image image;
    public float speed;
    private float speedBackup;
    private Color color;
    private int r;
    private int g;
    private int b;

    private void Start()
    {
        speed = speed / 100;
        speedBackup = speed;
        r = 0;
        g = 0;
        b = 0;
    }

    private void Update()
    {

        speed -= Time.deltaTime;

        if (speed <= 0)
        {
            if (r < 255)
            {
                r++;
            }
        }

        image.color = color;
    }

}
