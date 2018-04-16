using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassDisable : MonoBehaviour
{
    public List<GameObject> m_objects = new List<GameObject>();

    public void DisableAll()
    {
        foreach (GameObject go in m_objects) go.SetActive(false);
    }
}
