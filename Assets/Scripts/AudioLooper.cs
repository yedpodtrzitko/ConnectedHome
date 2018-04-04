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
        StartCoroutine(_AudioBegToMid(1f));
    }
    
    private void InitializeAudioSources()
    {
        if(m_audioSource == null)
            m_audioSource = gameObject.AddComponent<AudioSource>();

        m_bufferSource = m_audioSource.gameObject.AddComponent<AudioSource>();

        m_audioSource.loop = false;
        m_bufferSource.loop = m_loop;

        m_bufferSource.playOnAwake  = m_audioSource.playOnAwake = false;
        m_bufferSource.panStereo    = m_audioSource.panStereo;
        m_bufferSource.spatialBlend = m_audioSource.spatialBlend;

        m_bufferSource.rolloffMode  = m_audioSource.rolloffMode;

        m_bufferSource.minDistance  = m_audioSource.minDistance;
        m_bufferSource.maxDistance  = m_audioSource.maxDistance;


        m_audioSource.clip = m_begTrack;
        m_bufferSource.clip = m_midTrack;
    }

    private void PrepEndAudioTrack()
    {
        m_bufferSource.clip = m_endTrack;
        m_bufferSource.Pause();
    }

    private void SwapAudioSources()
    {
        AudioSource t = m_audioSource;
        m_audioSource = m_bufferSource;
        m_bufferSource = t;
    }

    public void FadeSwapAudioSource(float fadeTime)
    {
        StartCoroutine(_FadeSwapAudioSource(fadeTime));
    }

    public IEnumerator _FadeSwapAudioSource(float fadeTime)
    {
        float _fadeTime = fadeTime;

        m_bufferSource.volume = 0f;
        m_bufferSource.Play();
        
        while(m_bufferSource.volume < 1f)
        {
            m_bufferSource.volume += Time.deltaTime / fadeTime;
            m_audioSource.volume = 1f - m_bufferSource.volume;

            fadeTime -= Time.deltaTime;
            yield return null;
        }

        m_bufferSource.volume = 1f;
        m_audioSource.volume = 0f;

        SwapAudioSources();
        m_bufferSource.Stop();
    }

    public IEnumerator _AudioBegToMid(float fadeTime)
    {
        yield return new WaitUntil(() => m_audioSource.clip.length - m_audioSource.time <= 1f);
        FadeSwapAudioSource(fadeTime);
        yield return new WaitForSeconds(fadeTime * 1.1f);
        PrepEndAudioTrack();
    }
}