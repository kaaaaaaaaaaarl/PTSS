using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    //----Main Menu
    public void QuitGame()
    {
        Debug.Log("QuitTest");
        Application.Quit();
    }

    //----Setting Menu
    [SerializeField] private AudioMixer audioMixer;
    public void SetMainVolume(float MainVolume)
    {
        audioMixer.SetFloat("MainVolume", Mathf.Log10(MainVolume) * 20);
    }

    public void SetMusicVolume(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicVolume) * 20);
    }

    public void SetSFXVolume(float SFXVolume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXVolume) * 20);
    }

    public void SetEffects()
    {

    }

    //----Select Menu
    public ToggleTest script;
    public void PlayGame()
    {
        string SelectedMap = script.SelectedMap;

        switch (SelectedMap)
        {
            case "Map1":
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("Map Unavailable");
                break;
    }
        
    }

    //----Audio Control
    public AudioSource ClickAudio;
    public void PlayClickAudio()
    {
        ClickAudio.Play();
    }
}
