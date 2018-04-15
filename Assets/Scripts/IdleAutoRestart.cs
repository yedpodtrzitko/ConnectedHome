using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAutoRestart : MonoBehaviour
{
    [SerializeField]
    float timeToIdle;
    float cTime;
    public static bool isInactive;

	// Use this for initialization
	void Start ()
    {
        cTime = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Valve.VR.OpenVR.System.GetTrackedDeviceActivityLevel(0) == Valve.VR.EDeviceActivityLevel.k_EDeviceActivityLevel_UserInteraction ||
        Valve.VR.OpenVR.System.GetTrackedDeviceActivityLevel(0) == Valve.VR.EDeviceActivityLevel.k_EDeviceActivityLevel_Unknown)
        {
            if (isInactive)
            {
                isInactive = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

            isInactive = false;
            cTime = 0;
        }

        else if (isInactive) return;

        if (Valve.VR.OpenVR.System.GetTrackedDeviceActivityLevel(0) == Valve.VR.EDeviceActivityLevel.k_EDeviceActivityLevel_Idle ||
            Valve.VR.OpenVR.System.GetTrackedDeviceActivityLevel(0) == Valve.VR.EDeviceActivityLevel.k_EDeviceActivityLevel_Standby ||
            Valve.VR.OpenVR.System.GetTrackedDeviceActivityLevel(0) == Valve.VR.EDeviceActivityLevel.k_EDeviceActivityLevel_UserInteraction_Timeout)
        {
            cTime += Time.deltaTime;
        }

        if(cTime >= timeToIdle)
        {
            isInactive = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
