using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeToInvoke : MonoBehaviour
{
    public List<GameObject> m_offerings = new List<GameObject>();
    public UnityEngine.Events.UnityEvent m_action;
	
	void FixedUpdate ()
    {
		foreach(GameObject go in m_offerings)
            if (go.activeSelf)
                return;

        m_action.Invoke();

        m_offerings.Clear();
        Destroy(this);
	}
}