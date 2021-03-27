using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    SoundManager SoundManager;

    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        SoundManager.VolumeSlider = transform.Find("Volume").GetComponent<Slider>();
        SoundManager.Initialize();
        SoundManager.Play("Title");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
}
