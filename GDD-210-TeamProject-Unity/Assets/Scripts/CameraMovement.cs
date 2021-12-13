using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Sensitivity;
    public float YSensitivity;
    public Transform CamTransform;
    private float camRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseInputY = Input.GetAxisRaw("Mouse Y") * YSensitivity * Time.deltaTime;
        camRotation -= mouseInputY;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float mouseInputX = Input.GetAxisRaw("Mouse X") * Sensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX, 0f));

    }

}

