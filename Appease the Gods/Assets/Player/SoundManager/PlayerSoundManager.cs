using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoundManager : MonoBehaviour
{
    AudioSource[] AudioSources;

    public void PlaySound(string soundName)
    {
        switch(soundName)
        {
            case "WoodHit":
                AudioSources[0].Play();
                break;
            case "StoneHit":
                AudioSources[1].Play();
                break;
            case "MetalHit":
                AudioSources[2].Play();
                break;
            case "Footstep":
                AudioSources[3].Play();
                break;
            case "Jumping":
                AudioSources[4].Play();
                break;
            case "UIClick":
                AudioSources[5].Play();
                break;
            case "UIExit":
                AudioSources[6].Play();
                break;
            case "DamagePlayer":
                AudioSources[7].Play();
                break;
            case "ShrekSoundOne":
                AudioSources[8].Play();
                break;
            case "ShrekSoundTwo":
                AudioSources[9].Play();
                break;
            case "ShrekSoundThree":
                AudioSources[10].Play();
                break;

// Add Background Music Here

        }
    }

    public void StopSound(string soundName)
    {
        switch(soundName)
        {
            case "WoodHit":
                AudioSources[0].Stop();
                break;
            case "StoneHit":
                AudioSources[1].Stop();
                break;
            case "MetalHit":
                AudioSources[2].Stop();
                break;
            case "Footstep":
                AudioSources[3].Stop();
                break;
            case "Jumping":
                AudioSources[4].Stop();
                break;
            case "UIClick":
                AudioSources[5].Stop();
                break;
            case "UIExit":
                AudioSources[6].Stop();
                break;
            case "DamagePlayer":
                AudioSources[7].Stop();
                break;
            case "ShrekSoundOne":
                AudioSources[8].Stop();
                break;
            case "ShrekSoundTwo":
                AudioSources[9].Stop();
                break;
            case "ShrekSoundThree":
                AudioSources[10].Stop();
                break;

// Add Background Music Here

        }
    }

    public void ChangeVolume(float volume)
    {
        var AllAudioSourcesInScene = FindObjectsOfType<AudioSource>();

        for(int i = 0; i < AllAudioSourcesInScene.Length; i++)
        {
            AllAudioSourcesInScene[i].volume = volume;
        }

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        
    }

    void Start()
    {
        AudioSources = GetComponents<AudioSource>();
        var AllAudioSourcesInScene = FindObjectsOfType<AudioSource>();
        
        if(PlayerPrefs.HasKey("Volume"))
        {
            for(int i = 0; i < AllAudioSourcesInScene.Length; i++)
            {
                AllAudioSourcesInScene[i].volume = PlayerPrefs.GetFloat("Volume");
            }
        }
       else
        {
           PlayerPrefs.SetFloat("Volume", 1.0f);
        }

    }
}
