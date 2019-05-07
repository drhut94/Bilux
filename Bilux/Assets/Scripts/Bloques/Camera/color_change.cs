using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class color_change : MonoBehaviour {

    public PostProcessingProfile PPcolor;
    private Player script;
    


	void Start () {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {

        if (script.health <= 0)
        {
            ColorGradingModel.Settings colorSettings = PPcolor.colorGrading.settings;
            colorSettings.basic.saturation = 0;
            //Debug.Log(colorSettings.basic.saturation);
            PPcolor.colorGrading.settings = colorSettings;
        }
        else
        {
            ColorGradingModel.Settings colorSettings = PPcolor.colorGrading.settings;
            colorSettings.basic.saturation = 1;
            //Debug.Log(colorSettings.basic.saturation);
            PPcolor.colorGrading.settings = colorSettings;
        }
	}
}
