using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTextureResize : MonoBehaviour
{
    public List<Texture> m_textures = new List<Texture>();

	void Start ()
    {
        Material newMat = new Material(Shader.Find("Unlit/Texture"));
        newMat.mainTexture = m_textures[Random.Range(0, m_textures.Count)];
        GetComponent<Renderer>().material = newMat;

        Vector3 adjustedScale = Vector3.zero;
        adjustedScale.x = ((float)newMat.mainTexture.width / (float)newMat.mainTexture.height);
        adjustedScale.y = 1f;
        adjustedScale.z = transform.localScale.z;

        transform.localScale = adjustedScale;
    }
	
	void Update ()
    {
		
	}
}
