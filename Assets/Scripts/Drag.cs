using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 directionToMouse = mousePosition - objPosition;
        float distanceToMouse = Vector3.Distance(objPosition, mousePosition);
        transform.Translate(directionToMouse * distanceToMouse);

        print("Hello");
            
    }
}
