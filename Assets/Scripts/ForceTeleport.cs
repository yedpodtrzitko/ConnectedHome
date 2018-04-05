using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTeleport : MonoBehaviour
{
    public UnityEngine.UI.Image blindfold;
    public float fadeTime;
    private Vector3 originalPos;
    private Quaternion originalRot;
    public GameObject objectRef;



    // ---------- ---------- ---------- ---------- ---------- 
    private void Start()
    {
        if (objectRef == null) { objectRef = gameObject; }

        originalPos = objectRef.transform.position;
        originalRot = objectRef.transform.rotation;
    }


    // ---------- ---------- ---------- ---------- ---------- 
    public void TeleportPlayerToTransform(Transform pos)
    {
        StartCoroutine(FadeInOut());

        objectRef.transform.position = pos.position;
        objectRef.transform.rotation = pos.rotation;
    }


    // ---------- ---------- ---------- ---------- ---------- 
    public void ResetToOriginalPosIn(float time)
    {
        StartCoroutine(TimeToTeleportBack(time));
    }


    // ---------- ---------- ---------- ---------- ---------- 
    public void SetOriginalValuesToCurrent()
    {
        originalPos = objectRef.transform.position;
        originalRot = objectRef.transform.rotation;
    }

    // ---------- ---------- ---------- ---------- ---------- 
    public void SetOriginalValuesTo(Transform newValues)
    {
        originalPos = newValues.position;
        originalRot = newValues.rotation;
    }



    // ---------- ---------- ---------- ---------- ---------- 
    public IEnumerator FadeInOut()
    {
        Color c = blindfold.color;
        print(blindfold.color);
        c.a = 1f;
        blindfold.color = c;

        if (blindfold != null)
        {
            while (blindfold.color.a > 0.01f)
            {
                c.a -= (Time.deltaTime / fadeTime);
                blindfold.color = c;
                yield return null;
            }

            c.a = 0f;
            blindfold.color = c;
        }
    }


    // ---------- ---------- ---------- ---------- ---------- 
    public IEnumerator TimeToTeleportBack(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeInOut());
        objectRef.transform.position = originalPos;
        objectRef.transform.rotation = originalRot;
    }
}