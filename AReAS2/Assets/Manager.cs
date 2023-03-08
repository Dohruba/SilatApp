using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public enum Language
{
    english = 0,
    malay = 1
}
public class Manager : MonoBehaviour
{
    private static Language chosenLanguage = Language.english;

    public static Language ChosenLanguage { get => chosenLanguage; set => chosenLanguage = value; }


    private void Start()
    {
        StopAllAuidoAndVideo();
    }
    public void SetLanguage(Language language)
    {
        ChosenLanguage = language;
    }
    
    public void StopAllAuidoAndVideo()
    {
        StopAllAudio();
        StopAllVideo();
    }

    private void StopAllAudio()
    {
        GameObject[] audioSources = GameObject.FindGameObjectsWithTag("VoiceOver");

        foreach(GameObject gameObject in audioSources)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
    private void StopAllVideo()
    {
        GameObject[] videoSources = GameObject.FindGameObjectsWithTag("VideoPanel");

        foreach(GameObject gameObject in videoSources)
        {
            gameObject.GetComponent<VideoPlayer>().Stop();
        }

    }

    public void OnTapUpdateLanguage(int i)
    {
        StopAllAudio();
        ChosenLanguage = (Language)i;
        GameObject[] activePages = GameObject.FindGameObjectsWithTag("Page");
        bool isOn;
        foreach(GameObject activePage in activePages)
        {
            isOn = activePage.GetComponentInChildren<PageController>().GetIsOn();
            if (activePage != null && isOn)
            {
                activePage.GetComponentInChildren<PageController>().SetLanguage();
            }

        }
        Debug.Log("Update language: " + ChosenLanguage.ToString());
    }
}
