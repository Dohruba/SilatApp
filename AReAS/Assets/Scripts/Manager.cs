using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using System;

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
    private GameObject idleVideoPanel;
    [SerializeField]
    private GameObject interactionVideoPanel;

    private VideoPlayer idleVideoPlayer;
    private VideoPlayer interactionVideoPlayer;

    [SerializeField]
    private TMP_Text descriptionPanel;
    [SerializeField]
    private TMP_Text title;
    private State state;

    private bool allowStateChange;


    private void Start()
    {
        idleVideoPlayer = idleVideoPanel.GetComponent<VideoPlayer>();
        interactionVideoPlayer = interactionVideoPanel.GetComponent<VideoPlayer>();
        state = State.idle;
        EnterIdleState();
        StartCoroutine(UpdateState());
    }

    public void CallUpdateState(State newState)
    {
        state = newState;
    }
    private IEnumerator UpdateState()
    {
        State oldState = state;

        while (allowStateChange)
        {
            yield return new WaitUntil(() => oldState != state);
            OnStateChange();
            oldState = state;
        }
    }

    private void OnStateChange()
    {
        switch (state)
        {
            case State.idle:
                EnterIdleState();
                break;
            case State.interacting:
                EnterInteractiveState();
                break;
            case State.photos:
                EnterPhotoState();
                break;
            case State.end:
                EnterEndState();
                break;
            default:
                break;
        }
    }

    private void EnterEndState()
    {
        throw new NotImplementedException();
    }

    private void EnterPhotoState()
    {
        throw new NotImplementedException();
    }

    private void EnterInteractiveState()
    {
        throw new NotImplementedException();
    }

    private void EnterIdleState()
    {
        ActivateVideoPlayers(true, false);
    }

    private void ActivateVideoPlayers(bool isIdle, bool isInteraction)
    {
        if(isIdle && isInteraction)
        {
            throw new Exception("State error. Idle and Interaction active");
        }
        VideoPlayerToggle(false, interactionVideoPlayer);
        VideoPlayerToggle(false, idleVideoPlayer);

        idleVideoPanel.SetActive(isIdle);
        interactionVideoPanel.SetActive(isInteraction);

        if (isIdle)
        {
            VideoPlayerToggle(true, idleVideoPlayer);
        }
        else if(isInteraction)
        {
            VideoPlayerToggle(true, interactionVideoPlayer);
        }
    }



    //Help functions
    void VideoPlayerToggle(bool play, VideoPlayer player)
    {
        if (play)
        {
            player.Play();
        }
        else
        {
            player.Pause();
        }
    }
}
