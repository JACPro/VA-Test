using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    Vector3 startPos = Vector3.zero;
    Vector3 posChange = Vector3.zero;

    Quaternion startRotation;

    public void SetStartValues()
    {
        startPos = Input.mousePosition;
        startRotation = transform.rotation;
    }

    public void Rotate()
    {
        posChange = new Vector3((Input.mousePosition - startPos).y, 0, -(Input.mousePosition - startPos).x);
        transform.rotation = startRotation * Quaternion.Euler(Vector3.forward + posChange);
    }
}
