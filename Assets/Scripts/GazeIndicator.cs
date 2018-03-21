using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeIndicator : MonoBehaviour
{
    public GameObject m_3dCursor;

	void Update ()
    {
        m_3dCursor.transform.position = GetForwardRayPosition();
	}

    Vector3 GetForwardRayPosition()
    {
        RaycastHit rayHit;
        Physics.Raycast(transform.position, transform.forward, out rayHit);

        return rayHit.point;
    }
}
