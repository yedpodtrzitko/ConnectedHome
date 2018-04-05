using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelayedAction : MonoBehaviour
{
    public bool m_startOnStart;
    public float m_timeDelay;
    public UnityEngine.Events.UnityEvent m_actionEvent;

	// Use this for initialization
	void Start ()
    {
        if (m_startOnStart)
            FireDelayedAction(m_timeDelay, m_actionEvent);
	}

    public void FireInstantAction()
    {
        m_actionEvent.Invoke();
    }

    public void FireInstantAction(UnityEngine.Events.UnityEvent instantAction)
    {
        instantAction.Invoke();
    }

    public void FireDelayedAction(float timeDelay, UnityEngine.Events.UnityEvent delayedAction)
    {
        StartCoroutine(_FireDelayedAction(m_timeDelay, m_actionEvent));
    }

    public IEnumerator _FireDelayedAction(float timeDelay, UnityEngine.Events.UnityEvent delayedAction)
    {
        yield return new WaitForSeconds(timeDelay);
        delayedAction.Invoke();
    }
}
