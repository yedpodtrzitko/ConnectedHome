using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public bool rotateX, rotateY, rotateZ;
    public float rotationSpeed;
    public Vector3 rotationValues;
	
	void Update ()
    {
        if (rotateX)
        {
            transform.Rotate(Vector3.right, rotationValues.x * rotationSpeed);
        }
        if (rotateY)
        {
            transform.Rotate(Vector3.up, rotationValues.y * rotationSpeed);
        }
        if (rotateZ)
        {
            transform.Rotate(Vector3.forward, rotationValues.z * rotationSpeed);
        }
    }
}
