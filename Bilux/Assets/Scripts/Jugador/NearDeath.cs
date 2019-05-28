using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class NearDeath : MonoBehaviour {


    public PostProcessingProfile PPcolor;
    private float VigneteDefault;
    private float VigneteDamage;
    VignetteModel.Settings vigneteSettings;
    ChromaticAberrationModel.Settings aberrationSettings;
    private float aberration;
    public Player player;

    private void Start()
    {
        VigneteDamage = 0.6f;
        VigneteDefault = 0.06f;
        vigneteSettings = PPcolor.vignette.settings;
        vigneteSettings.intensity = 0.06f;
        PPcolor.vignette.settings = vigneteSettings;
        aberrationSettings = PPcolor.chromaticAberration.settings;
        aberrationSettings.intensity = 0;
        PPcolor.chromaticAberration.settings = aberrationSettings;
        aberration = 1f;
    }

    private void Update()
    {
        if (player.isActiveAndEnabled)
        {
            transform.position = player.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        vigneteSettings = PPcolor.vignette.settings;
        //vigneteSettings.intensity = 0.05f;

        if (collision.gameObject.CompareTag("Trap"))
        { 
            StopCoroutine("FadeDown");
            StartCoroutine("FadeUp");
            //vigneteSettings.intensity = 0.6f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        vigneteSettings = PPcolor.vignette.settings;

        if (collision.gameObject.CompareTag("Trap"))
        {
            StopCoroutine("FadeUp");
            StartCoroutine("FadeDown");
        }
    }

    public void ResetEffects()
    {
        vigneteSettings = PPcolor.vignette.settings;
        aberrationSettings = PPcolor.chromaticAberration.settings;
        aberrationSettings.intensity = 0;
        vigneteSettings.intensity = VigneteDefault;
        PPcolor.vignette.settings = vigneteSettings;
        PPcolor.chromaticAberration.settings = aberrationSettings;
    }

    public void PlayAberration()
    {
        StopCoroutine("FadeDownAberration");
        StopCoroutine("FadeUpAberration");
        StartCoroutine("FadeUpAberration");
    }

    IEnumerator FadeUp()
    {
        while (vigneteSettings.intensity < VigneteDamage)
        {
            vigneteSettings.intensity += 1 * Time.deltaTime;
            PPcolor.vignette.settings = vigneteSettings;
            yield return null;
        }
    }

    IEnumerator FadeDown()
    {
        while (vigneteSettings.intensity > VigneteDefault)
        {
            vigneteSettings.intensity += -1 * Time.deltaTime;
            PPcolor.vignette.settings = vigneteSettings;
            yield return null;
        }
    }

    IEnumerator FadeUpAberration()
    {
        while (aberrationSettings.intensity < aberration)
        {
            aberrationSettings.intensity += 15 * Time.deltaTime;
            PPcolor.chromaticAberration.settings = aberrationSettings;
            yield return null;
        }
        StartCoroutine("FadeDownAberration");
    }

    IEnumerator FadeDownAberration()
    {
        while (aberrationSettings.intensity > 0)
        {
            aberrationSettings.intensity += -8 * Time.deltaTime;
            PPcolor.chromaticAberration.settings = aberrationSettings;
            yield return null;
        }

    }
}
