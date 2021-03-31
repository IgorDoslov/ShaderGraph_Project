using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamController : MonoBehaviour
{
    public float lookSensitivity = 2.0f;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;
    public bool invertXRotation;
    private float curXRot;

    

    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void LateUpdate()
    {
        CamControl();
        
    }

    void CamControl()
    {
        if (PauseMenu.gameIsPaused == true)
            return;
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        if (invertXRotation)
            curXRot += y * lookSensitivity;
        else
            curXRot -= y * lookSensitivity;

        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;

        camAnchor.eulerAngles = clampedAngle;

    }

    
}
