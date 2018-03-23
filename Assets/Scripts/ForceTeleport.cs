using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTeleport : MonoBehaviour
{
    public UnityEngine.UI.Image blindfold;
    public float fadeTime;
    private Vector3 originalPos;
    private Quaternion originalRot;

    private void Start()
    {
        originalPos = Valve.VR.InteractionSystem.Player.instance.transform.position;
        originalRot = Valve.VR.InteractionSystem.Player.instance.transform.rotation;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Valve.VR.InteractionSystem.Player.instance.transform.position = originalPos;
            Valve.VR.InteractionSystem.Player.instance.transform.rotation = originalRot;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            TeleportPlayerToTransform(transform);
        }
    }

    public void TeleportPlayerToTransform(Transform pos)
    {
        Valve.VR.InteractionSystem.Player.instance.gameObject.SetActive(true);

        StartCoroutine(FadeInOut());

        Valve.VR.InteractionSystem.Player.instance.transform.position = pos.position;
        Valve.VR.InteractionSystem.Player.instance.transform.rotation = pos.rotation;

        StartCoroutine(TimeToTeleportBack());
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

    public IEnumerator TimeToTeleportBack()
    {
        yield return new WaitForSeconds(10f);

        Valve.VR.InteractionSystem.Player.instance.transform.position = originalPos;
        Valve.VR.InteractionSystem.Player.instance.transform.rotation = originalRot;
    }
}
