using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private Transform pivotPoint;

    Vector3 mouseRef;
    Vector3 mouseOffset;
    Vector3 rotation;
    bool isRotating= false;


    private void Start()
    {
        rotation = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }


        if (isRotating)
        {
            mouseOffset = Input.mousePosition - mouseRef;

            rotation.z = (mouseOffset.x + mouseOffset.y) * 0.2f;

            transform.RotateAround(pivotPoint.position, Vector3.up, rotation.z);

            mouseRef = Input.mousePosition;
        }
    }

    private void MouseDown()
    {
        isRotating = true;

        mouseRef = Input.mousePosition;
    }


    private void MouseUp()
    {
        isRotating = false;
    }

}
