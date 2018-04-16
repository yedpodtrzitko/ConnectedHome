using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationValues;
	
	void Update ()
    {
        transform.Rotate(Vector3.right, rotationValues.x * rotationSpeed);
        transform.Rotate(Vector3.up, rotationValues.y * rotationSpeed);        
        transform.Rotate(Vector3.forward, rotationValues.z * rotationSpeed);
    }
}
