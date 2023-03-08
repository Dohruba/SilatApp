using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : MonoBehaviour
{
    WebCamTexture webcam;
    public string path;
    public RawImage imageDisplay;
    private void Start()
    {
        webcam = new WebCamTexture(WebCamTexture.devices[8].name);
        GetComponent<Renderer>().material.mainTexture = webcam;
        webcam.Play();
    }
}
