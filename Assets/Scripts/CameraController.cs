using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    

    private Vector3 firstpoint;
    private Vector3 secondpoint;

    

    private float xAngle;
    private float yAngle;
    private float xAngTemp;
    private float yAngTemp;

    public RaycastShooting shooting;

    private bool isUpdatePosition = false;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnStartTouch();
            isUpdatePosition = true;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            isUpdatePosition = false;
            Camera.main.fieldOfView = 60f;
            shooting.Fire("Enemy");
        }

        if (isUpdatePosition)
        {
            UpdatePosition();
        }
    }

    private void OnStartTouch()
    {
        firstpoint = Input.mousePosition;

        xAngTemp = xAngle;
        yAngTemp = yAngle;
        Camera.main.fieldOfView = 15f;
    }

    public void UpdatePosition()
    {
        secondpoint = Input.mousePosition;

        xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
        yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;

        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);

    }
}

