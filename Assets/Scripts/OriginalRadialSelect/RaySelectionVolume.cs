using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class myFloatEvent : UnityEvent<float> { }

public class RaySelectionVolume : MonoBehaviour
{
    public bool isActing = false;
    public UnityEvent loadedAction;
}
