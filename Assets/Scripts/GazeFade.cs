using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeFade : MonoBehaviour
{
    [Range(1f, 10f)]
    public float FadeStrength;

    Renderer m_renderer;
    Transform m_mainCamera;
    Material[] m_mats;
    TMPro.TextMeshPro tmp;

	void Start ()
    {
        SetMaterialsToInstances();
        m_mainCamera = Camera.main.transform;
        tmp = GetComponent<TMPro.TextMeshPro>();
	}
	
	void Update ()
    {
        if (tmp != null)
        {
            Color color = tmp.color;
            color.a = 1 - (GetCameraAngle() / 180f) * FadeStrength;
            tmp.color = color;
        }

        else
        {
            foreach (Material mat in m_mats)
            {
                Color color = mat.color;
                color.a = 1 - (GetCameraAngle() / 180f) * FadeStrength;
                mat.color = color;
            }
        }
	}

    float GetCameraAngle()
    {
        Vector3 angleToCamera = transform.position - m_mainCamera.position;
        return Vector3.Angle(m_mainCamera.forward, angleToCamera);
    }

    void SetMaterialsToInstances()
    {
        m_renderer = GetComponent<Renderer>();

        m_mats = m_renderer.materials;
        m_renderer.materials = m_mats;
    }
}
