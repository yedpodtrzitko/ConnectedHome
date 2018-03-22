using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTextureManager : MonoBehaviour
{
    public void PlayVideoTexture()
    {
        GetComponent<UnityEngine.Video.VideoPlayer>().Play();
    }

    public void Update()
    {
        GetComponent<RaySelectionVolume>().isActing = GetComponent<UnityEngine.Video.VideoPlayer>().isPlaying;
    }
}
