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
        ColorGradingModel.Settings colorSettings = PPcolor.colorGrading.settings;
        colorSettings.basic.saturation = script.health / 100f;
        Debug.Log(colorSettings.basic.saturation);
        PPcolor.colorGrading.settings = colorSettings;
	}
}
