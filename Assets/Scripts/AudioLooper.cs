using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioSource m_audioSource;
    private AudioSource m_bufferSource;

    [Space]

    public bool m_playOnAwake;
    public bool m_loop;

    [Space]

    public AudioClip m_begTrack;
    public AudioClip m_midTrack;
    public AudioClip m_endTrack;



    private void Start()
    {
        InitializeAudioSources();

        if (m_playOnAwake) m_audioSource.Play();

        m_bufferSource.Pause();
    }


    private void InitializeAudioSources()
    {
        if(m_audioSource == null)
            m_audioSource = gameObject.AddComponent<AudioSource>();

        m_bufferSource = m_audioSource.gameObject.AddComponent<AudioSource>();


        m_bufferSource.playOnAwake  = m_audioSource.playOnAwake = false;
        m_bufferSource.panStereo    = m_audioSource.panStereo;
        m_bufferSource.spatialBlend = m_audioSource.spatialBlend;

        m_bufferSource.rolloffMode  = m_audioSource.rolloffMode;

        m_bufferSource.minDistance  = m_audioSource.minDistance;
        m_bufferSource.maxDistance  = m_audioSource.maxDistance;


        m_audioSource.clip = m_begTrack;
        m_bufferSource.clip = m_midTrack;
    }
}