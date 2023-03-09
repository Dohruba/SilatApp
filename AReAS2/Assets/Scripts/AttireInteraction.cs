using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttireInteraction : MonoBehaviour
{
    public GameObject[] belts;
    public GameObject[] headgears;
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
    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
