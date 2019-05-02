using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;
    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

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
        FindObjectOfType<AudioManager>().PlayMusic("music_level3", 0.0f);

        //StartCoroutine("StopSound", new object);

        //PlayMusic("music_level3", 10.0f);
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
