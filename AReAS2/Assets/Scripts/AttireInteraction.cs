using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttireInteraction : MonoBehaviour
{
    public GameObject[] belts;
    public GameObject[] headgears;
    public GameObject[] beltDescriptions;
    public GameObject[] headDescriptions;
    private int currentIndexBelt = 0;
    private int currentIndexHead = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject belt in belts)
        {
            belt.SetActive(false);
        }

        belts[0].SetActive(true);

        foreach (GameObject headgear in headgears)
        {
            headgear.SetActive(false);
        }

        headgears[0].SetActive(true);

        foreach (GameObject beltDescription in beltDescriptions)
        {
            beltDescription.SetActive(false);
        }

        beltDescriptions[0].SetActive(true);

        foreach (GameObject headDescription in headDescriptions)
        {
            headDescription.SetActive(false);
        }

        headDescriptions[0].SetActive(true);

    }

    public void OnBeltButtonClick()
    {
        if (currentIndexBelt < belts.Length - 1)
        {
            currentIndexBelt++;
        }
        else
        {
            currentIndexBelt = 0;
        }

        belts[currentIndexBelt].SetActive(true);
        belts[(currentIndexBelt + belts.Length - 1) % belts.Length].SetActive(false);

        // Update belt descriptions to match current index
        for (int i = 0; i < beltDescriptions.Length; i++)
        {
            if (i == currentIndexBelt)
            {
                beltDescriptions[i].SetActive(true);
            }
            else
            {
                beltDescriptions[i].SetActive(false);
            }
        }
    }

    public void OnHeadButtonClick()
    {
        if (currentIndexHead < headgears.Length - 1)
        {
            currentIndexHead++;
        }
        else
        {
            currentIndexHead = 0;
        }

        headgears[currentIndexHead].SetActive(true);
        headgears[(currentIndexHead + headgears.Length - 1) % headgears.Length].SetActive(false);

        // Update headgear descriptions to match current index
        for (int i = 0; i < headDescriptions.Length; i++)
        {
            if (i == currentIndexHead)
            {
                headDescriptions[i].SetActive(true);
            }
            else
            {
                headDescriptions[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
