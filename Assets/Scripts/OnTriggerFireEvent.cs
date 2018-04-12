using UnityEngine;
using System.Collections.Generic;

public class OnTriggerFireEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent m_event;
    public List<string> m_tags;

    void OnTriggerEnter(Collider other)
    {
        if (m_tags.Count > 0)
            if (!m_tags.Contains(other.gameObject.tag))
                return;

        m_event.Invoke();
    }
}