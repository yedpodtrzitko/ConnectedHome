using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationTrigger : MonoBehaviour
{
    Animator m_animator;

	void Start ()
    {
        m_animator = GetComponent<Animator>();
	}
	
    public void FireTrigger(string triggerName)
    {
        m_animator.SetTrigger(triggerName);
    }

    public void DisableGameobject(GameObject go)
    {
        go.SetActive(false);
    }
}
