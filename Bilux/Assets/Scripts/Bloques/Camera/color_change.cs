using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class color_change : MonoBehaviour {

    public PostProcessingProfile PPcolor;
    private Player script;
    public CircleCollider2D circle;
    


	void Start () {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {

        ColorGradingModel.Settings colorSettings = PPcolor.colorGrading.settings;

        if (script.health <= 0)
        {
            colorSettings.basic.saturation = 0;
        }
        else
        {
            colorSettings.basic.saturation = 1;
        }

        PPcolor.colorGrading.settings = colorSettings;
    }

}
