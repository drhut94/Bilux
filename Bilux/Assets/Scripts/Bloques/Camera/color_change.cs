using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class color_change : MonoBehaviour {

    public PostProcessingProfile PPcolor;
    private Player script;
    private ColorGradingModel.Settings colorSettings;




    void Start () {
        colorSettings = PPcolor.colorGrading.settings;
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        colorSettings.basic.saturation = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (script.isDead)
        {
            colorSettings.basic.saturation = 0;
        }
        //Debug.Log(colorSettings.basic.saturation);
        PPcolor.colorGrading.settings = colorSettings;
	}

    public void ChangeScreenColor(int color)
    {
        if (color == 0)
        {
            colorSettings.basic.saturation = 0;
        }
        else if (color == 1)
        {
            colorSettings.basic.saturation = 1;
        }
    }
}
