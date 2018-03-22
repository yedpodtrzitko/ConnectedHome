using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTextureManager : MonoBehaviour
{
    public void PlayVideoTexture()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
}
