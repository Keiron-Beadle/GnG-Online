using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public PlayerController playerController;

    float xRot = 0f;
    public float mouseSensitivity = 100f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        bool firstPerson = playerController.firstPerson;
        if (firstPerson)
        {
            FirstPersonUpdate();
        }
        else
        {
            ThirdPersonUpdate();
        }
    }

    void FirstPersonUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerTransform.Rotate(Vector3.up * mouseX);
    }

    void ThirdPersonUpdate()
    {

    }
}
