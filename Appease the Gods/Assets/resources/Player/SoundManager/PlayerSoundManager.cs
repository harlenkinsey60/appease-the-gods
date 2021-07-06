using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoundManager : MonoBehaviour
{
    AudioSource[] AudioSources;

    private float WalkSpeed = 0.45f;
    private float RunSpeed = 0.325f;
    private float GatherSpeed = 0.45f;

    private IEnumerator WalkCoroutine()
    {
        while (true)
        {    
            yield return new WaitForSeconds(WalkSpeed);
            AudioSources[3].Play();
        }
    }

    private IEnumerator RunCoroutine()
    {
        while (true)
        {    
            yield return new WaitForSeconds(RunSpeed);
            AudioSources[3].Play();
        }
    }

    private IEnumerator GatherWoodCoroutine()
    {
        while (true)
        {    
            yield return new WaitForSeconds(GatherSpeed);
            AudioSources[0].Play();
        }
    }

    private IEnumerator GatherStoneCoroutine()
    {
        while (true)
        {    
            yield return new WaitForSeconds(GatherSpeed);
            AudioSources[1].Play();
        }
    }

    private IEnumerator GatherMetalCoroutine()
    {
        while (true)
        {    
            yield return new WaitForSeconds(GatherSpeed);
            AudioSources[2].Play();
        }
    }
    

    public void PlaySound(string soundName)
    {
        switch(soundName)
        {
            case "WoodHit":
                StartCoroutine("GatherWoodCoroutine");
                break;
            case "StoneHit":
                StartCoroutine("GatherStoneCoroutine");
                break;
            case "MetalHit":
                StartCoroutine("GatherMetalCoroutine");
                break;
            case "Walking":
                StartCoroutine("WalkCoroutine");
                break;
            case "Running":
                StartCoroutine("RunCoroutine");
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
                StopCoroutine("GatherWoodCoroutine");
                break;
            case "StoneHit":
                StopCoroutine("GatherStoneCoroutine");
                break;
            case "MetalHit":
                StopCoroutine("GatherMetalCoroutine");
                break;
            case "Walking":
                StopCoroutine("WalkCoroutine");
                break;
            case "Running":
                StopCoroutine("RunCoroutine");
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
