using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchParentRotation : MonoBehaviour
{
	void Update ()
    {
        transform.localRotation = transform.parent.rotation;
	}
}
