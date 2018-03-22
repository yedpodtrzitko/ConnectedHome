using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaCoasteriTween : MonoBehaviour
{
	void Start ()
    {
        iTween.MoveTo(gameObject,
            iTween.Hash(
            "path", iTweenPath.GetPath("SofaPath"),
            //"easetype", iTween.EaseType.easeInSine,
            "time", 60,
            "orienttopath", true,
            "lookahead", 0.5));

    }
	
	void Update ()
    {
		
	}
}
