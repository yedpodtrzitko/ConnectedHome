using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTextureResize : MonoBehaviour
{

    public List<Texture> m_textures = new List<Texture>();
    private List<Texture> m_nonRepeatTextures;

	void Start ()
    {
        if (m_nonRepeatTextures == null) m_nonRepeatTextures = new List<Texture>();

        if (m_nonRepeatTextures.Count < 1)
            foreach (Texture tex in m_textures)
                m_nonRepeatTextures.Add(tex);


        Material newMat = new Material(Shader.Find("Unlit/Texture"));

        int randomIndex = Random.Range(0, m_nonRepeatTextures.Count);
        newMat.mainTexture = m_nonRepeatTextures[randomIndex];
        m_nonRepeatTextures.RemoveAt(randomIndex);

        GetComponent<Renderer>().material = newMat;

        Vector3 adjustedScale = Vector3.zero;
        adjustedScale.x = newMat.mainTexture.width / newMat.mainTexture.height;
        adjustedScale.y = 1f;
        adjustedScale.z = transform.localScale.z;

        adjustedScale.Normalize();

        transform.localScale = adjustedScale;
    }
	
	void Update ()
    {
		
	}
}
