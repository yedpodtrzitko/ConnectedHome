using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOffset : MonoBehaviour
{
    public Transform m_target;
    private Vector3 m_offset;

	void Start ()
    {
        if (m_target == null) Destroy(this);

        else m_offset = transform.position - m_target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!m_target.gameObject.activeSelf) return;

        else
        {
            transform.position = m_target.position + m_offset;
        }
	}
}
