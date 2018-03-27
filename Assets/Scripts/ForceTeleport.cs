using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTeleport : MonoBehaviour
{
    public UnityEngine.UI.Image blindfold;
    public float fadeTime;
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Valve.VR.InteractionSystem.Player playerRef;

    private void Start()
    {
        playerRef = Valve.VR.InteractionSystem.Player.instance;
        originalPos = playerRef.transform.position;
        originalRot = playerRef.transform.rotation;
    }

    public void TeleportPlayerToTransform(Transform pos)
    {
        StartCoroutine(FadeInOut());

        playerRef.transform.position = pos.position;
        playerRef.transform.rotation = pos.rotation;
    }

    public void ResetToOriginalPosIn(float time)
    {
        StartCoroutine(TimeToTeleportBack(time));
    }

    public IEnumerator FadeInOut()
    {
        Color c = blindfold.color;
        print(blindfold.color);
        c.a = 1f;
        blindfold.color = c;

        while (blindfold.color.a > 0.01f)
        {
            c.a -= (Time.deltaTime / fadeTime);
            blindfold.color = c;
            yield return null;
        }

        c.a = 0f;
        blindfold.color = c;
    }

    public IEnumerator TimeToTeleportBack(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeInOut());
        playerRef.transform.position = originalPos;
        playerRef.transform.rotation = originalRot;
    }
}