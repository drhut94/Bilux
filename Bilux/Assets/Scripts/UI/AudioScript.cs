using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

    public AudioMixer mixer;
    public string groupName;

    public void SetLevel(Slider slider)
    {
        mixer.SetFloat(groupName, Mathf.Log10(slider.value) * 20);
    }
}
