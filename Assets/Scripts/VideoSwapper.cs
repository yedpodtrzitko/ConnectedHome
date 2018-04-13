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
	
	// Update is called once per frame
	void Update ()
    {
		
	}


}
