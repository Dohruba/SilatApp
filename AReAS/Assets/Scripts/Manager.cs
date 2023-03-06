using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public enum State
{
    idle = 0,
    interacting = 1,
    photos = 2,
    end = 3
}
public class Manager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPanel;

    private void Start()
    {
        if (videoPanel.isPlaying)
        {

        }
    }
}
