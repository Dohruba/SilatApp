using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PageController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioEN;
    [SerializeField]
    private AudioClip audioMY;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject model;

    [Space]
    [SerializeField]
    private VideoClip videoEN;
    [SerializeField]
    private VideoClip videoMY;
    [SerializeField]
    private VideoPlayer player;


    [SerializeField]
    private bool isOn = false;
    public bool isVideo = false;

    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetLanguage()
    {
        if (isVideo)
        {
            SetVideoLanguage();
        }
        else
        {
            SetAudioLanguage();
        }
    }

    private void SetAudioLanguage()
    {
        Debug.Log("Language Update called on page");
        if (audioSource.clip != null)
        {

            Debug.Log("Stopping audio");
            audioSource.Stop();
        }
        if (Manager.ChosenLanguage == Language.english) //set language according to manager
        {
            audioSource.clip = audioEN;
            Debug.Log("Language: English");
        }
        else
        {
            audioSource.clip = audioMY;
            Debug.Log("Language: Malay");
        }
        audioSource.Play();
    }

    private void SetVideoLanguage()
    {
        Debug.Log("Language Update called on page");
        if (audioSource.clip != null)
        {

            Debug.Log("Stopping video");
            player.Stop();
        }
        if (Manager.ChosenLanguage == Language.english) //set language according to manager
        {
            player.clip = videoEN;
            Debug.Log("Language: English");
        }
        else
        {
            player.clip = videoMY;
            Debug.Log("Language: Malay");
        }
        player.Play();
    }
    private IEnumerator ElevateModel(bool up)
    {
        if (model != null)
        {
            float distance = 0.2f;
            float remainingDistance = distance;
            float traveledDistance = remainingDistance - distance;
            float fractionOfTravel = traveledDistance / distance;
            float startTime = Time.time;
            Vector3 startPosition = gameObject.transform.localPosition ;
            Vector3 endPosition = up? startPosition + new Vector3(0, distance, 0): startPosition - new Vector3(0, distance, 0);
            while (remainingDistance > 1f)
            {
                yield return new WaitForEndOfFrame();
                traveledDistance = (Time.time - startTime) * speed;
                fractionOfTravel = traveledDistance / distance;
                gameObject.transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfTravel);
                remainingDistance = Vector3.Distance(gameObject.transform.localPosition, endPosition);
            }
        }
    }

    public void StartElevation()
    {

        if (model != null)
        {
            StartCoroutine(ElevateModel(true));
        }
    }
    public void StartDelevation()
    {

        if (model != null)
        {
            StartCoroutine(ElevateModel(false));
        }
    }
    public void SetIsOn(bool isContentOn)
    {
        isOn = isContentOn;
    }
    public bool GetIsOn()
    {
        return isOn;
    }
}
