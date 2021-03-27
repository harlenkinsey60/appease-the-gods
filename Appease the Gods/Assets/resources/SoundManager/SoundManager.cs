using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource[] AudioSources;
    AudioClip Title;
    public Slider VolumeSlider;

    public void Play(string soundName)
    {
        switch(soundName)
        {
            case "Title":
                AudioSources[0].clip = Title;
                AudioSources[0].Play();
                break;
        }
    }

    public void ChangeVolume()
    {
        for(int i = 0; i < AudioSources.Length; i++)
        {
            AudioSources[i].volume = VolumeSlider.value;
        }

        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
        PlayerPrefs.Save();
        
    }

    public void Initialize()
    {
        AudioSources = GetComponents<AudioSource>();
        Title = Resources.Load<AudioClip>("SoundManager/Sounds/Title");
        
        if(PlayerPrefs.HasKey("Volume"))
        {
            for(int i = 0; i < AudioSources.Length; i++)
            {
                AudioSources[i].volume = PlayerPrefs.GetFloat("Volume");
            }
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
       else
        {
           PlayerPrefs.SetFloat("Volume", 1.0f);
           VolumeSlider.value = 1.0f;
        }
    }
}
