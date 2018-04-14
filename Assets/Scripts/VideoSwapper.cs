using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.Video.VideoPlayer))]
public class VideoSwapper : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer m_videoPlayer;
    public UnityEngine.Video.VideoClip m_defaultClip;

    public bool m_playOnAwake;

	// Use this for initialization
	void Start ()
    {
        m_videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        m_videoPlayer.clip = m_defaultClip;
	}
	


    public void SwitchToDefault(bool play)
    {
        SwitchVideoClip(m_defaultClip);
        if(play) Play();
    }

    public void SwitchVideoClip(UnityEngine.Video.VideoClip newClip)
    {
        Stop();
        m_videoPlayer.clip = newClip;
    }



    public void Play()
    {
        m_videoPlayer.Play();
    }

    public void Pause()
    {
        m_videoPlayer.Pause();
    }

    public void Stop()
    {
        m_videoPlayer.Stop();
    }
}
