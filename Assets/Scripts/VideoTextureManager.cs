using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTextureManager : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer m_VP;


    private void Start()
    {
        m_VP = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    public void PlayVideoTexture()
    {
        m_VP.Play();
    }

    public void PlayPauseVideoTexture()
    {
        if (m_VP.isPlaying)
            m_VP.Pause();
        else
            m_VP.Play();
    }

    public void Update()
    {
        //GetComponent<RaySelectionVolume>().isActing = GetComponent<UnityEngine.Video.VideoPlayer>().isPlaying;
    }
}
