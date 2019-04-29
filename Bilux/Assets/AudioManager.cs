﻿using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;

            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.pitch = sounds[i].pitch;
        }
	}
	
	public void PlaySound (string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == name)
            {
                sounds[i].source.Play();
            }
        }
    }
}
