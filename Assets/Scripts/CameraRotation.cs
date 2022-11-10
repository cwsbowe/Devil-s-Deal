using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public Transform orientation;
    private float xRot;
    private float yRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * horizontalSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * verticalSensitivity;

        //This is because the rotation is around the axis whereas the mouse movement is on the axis
        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
