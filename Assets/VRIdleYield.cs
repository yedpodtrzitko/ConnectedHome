using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRIdleYield : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent m_onVRActive;

	// Use this for initialization
	public IEnumerator Start ()
    {
        yield return new WaitWhile(() => IdleAutoRestart.isInactive);

        m_onVRActive.Invoke();
        Destroy(this);
	}
}
