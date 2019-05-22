using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;
    public static AudioManager instance;
    public string musicName;

    public AudioMixer mixer;
    public AudioMixerGroup audioMusic;
    public AudioMixerGroup audioEffects;

    public Slider musicSlider;
    public Slider effectsSlider;

    public void SetMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetEffects(float sliderValue)
    {
        mixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", sliderValue); 
    }

    // Use this for initialization
    void Awake () {

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //DontDestroyOnLoad(gameObject);

		for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;

            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.pitch = sounds[i].pitch;
            sounds[i].source.loop = sounds[i].loop;
        }
	}

    public void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic(musicName, 0.0f);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        mixer.SetFloat("EffectsVol", Mathf.Log10(PlayerPrefs.GetFloat("EffectsVolume")) * 20);

        if (PlayerPrefs.HasKey("MusicVolume") && musicSlider != null)
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey("EffectsVolume") && effectsSlider != null)
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");


        //StartCoroutine("StopSound", new object);

        //PlayMusic("music_level3", 10.0f);
        sounds[0].source.outputAudioMixerGroup = audioMusic;
        sounds[0].source.outputAudioMixerGroup = audioMusic;
        sounds[12].source.outputAudioMixerGroup = audioMusic;
        sounds[13].source.outputAudioMixerGroup = audioMusic;
        sounds[15].source.outputAudioMixerGroup = audioMusic;
        sounds[17].source.outputAudioMixerGroup = audioMusic;
        sounds[18].source.outputAudioMixerGroup = audioMusic;
        sounds[19].source.outputAudioMixerGroup = audioMusic;
        sounds[20].source.outputAudioMixerGroup = audioMusic;
        for (int i = 1; i < 12; i++)
        {
            sounds[i].source.outputAudioMixerGroup = audioEffects;
        }
        sounds[14].source.outputAudioMixerGroup = audioEffects;
        sounds[16].source.outputAudioMixerGroup = audioEffects;
    }

    public void PlaySound (string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == name)
            {
                sounds[i].source.volume = 1;
                sounds[i].source.Play();
            }
        }
    }

    public void PlayMusic (string name, float time)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                object[] parameters = new object[2] { i, time };
                StartCoroutine("FadeInSound", parameters);
            }
        }
    }

    public void StopSound (string name, float time)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                object[] parameters = new object[2] { i, time};
                StartCoroutine("FadeOutSound", parameters);
            }
        }
    }

    IEnumerator FadeOutSound (object[] param)
    {
        while (sounds[(int)param[0]].source.volume > 0.0f)
        {
            sounds[(int)param[0]].source.volume -= Time.deltaTime / (float)param[1];
            yield return null;
        }
            sounds[(int)param[0]].source.Stop();
        sounds[(int)param[0]].source.Stop();
    }

    IEnumerator FadeInSound (object[] param)
    {
        sounds[(int)param[0]].source.volume = 0;
        sounds[(int)param[0]].source.Play();

        while (sounds[(int)param[0]].source.volume < 1.0f)
        {
            sounds[(int)param[0]].source.volume += Time.deltaTime / (float)param[1];
            yield return null;
        }
    }
}
