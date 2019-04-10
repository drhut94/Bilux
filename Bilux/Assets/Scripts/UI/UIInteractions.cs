using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public AudioMixer mixer;
    public GameObject menu;
    public string group;

    public void Slider(Slider slider)
    {
        slider.value = slider.maxValue;

        slider.onValueChanged.AddListener((float u) => SetVolume(u, slider));
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
    }

    public void Settings(GameObject settings)
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Selector(GameObject selector)
    {
        selector.SetActive(true);
        menu.SetActive(false);
    }

    public void BackMenu(GameObject UI)
    {
        UI.SetActive(false);
        menu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("demo", LoadSceneMode.Single);
    }

    void SetVolume(float value, Slider slider)
    {
        mixer.SetFloat(mixer., ConvertToDecibel(value / slider.maxValue));
    }

    float ConvertToDecibel(float value)
    {
        return Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
    }
}   

