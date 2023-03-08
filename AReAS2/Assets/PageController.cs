using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private bool isOn = false;

    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        //SetLanguage();
    }

    public void SetLanguage()
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
