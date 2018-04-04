using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRender : MonoBehaviour
{
    Renderer renderer;
    bool wasRendering = false;

    public UnityEngine.Events.UnityEvent OnVisible;
    public UnityEngine.Events.UnityEvent OnHide;

    IEnumerator Start()
    {
        renderer = GetComponent<Renderer>();

        while (Application.isPlaying)
        {

            if (renderer.isVisible == true && wasRendering == false)
            {
                print("visible");
                OnVisible.Invoke();
            }


            else if (renderer.isVisible == false && wasRendering == true)
            {

                print("invisible");
                OnHide.Invoke();
            }

            wasRendering = renderer.isVisible;

            yield return new WaitForSeconds(1.0f);
        }
    }
}