using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVoiceYield : MonoBehaviour
{
    public AudioSource m_audioSource;

	// Use this for initialization
	public IEnumerator Start ()
    {
        m_audioSource = GetComponent<AudioSource>();

        yield return new WaitWhile(() => IdleAutoRestart.isInactive);

        m_audioSource.Play();
	}
}
