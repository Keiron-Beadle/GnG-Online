using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public Transform playerTransform;
    public PlayerController playerController;

    float xRot = 0f;
    public float mouseSensitivity = 100f;

    void LateUpdate()
    {
        bool firstPerson = playerController.firstPerson;
        if (firstPerson)
        {
            Cursor.lockState = CursorLockMode.Locked;
            FirstPersonUpdate();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            ThirdPersonUpdate();
        }
    }

    public void Enable()
    {
        playerCamera.enabled = true;
    }

    public void Disable()
    {
        playerCamera.enabled = false;
    }

    void FirstPersonUpdate()
    {
        transform.position = playerTransform.position + new Vector3(0f, 2f, 0f);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerTransform.Rotate(Vector3.up * mouseX);
    }

    void ThirdPersonUpdate()
    {
        transform.position = playerTransform.position + new Vector3(13f, 24f, 0f);
        transform.localRotation = Quaternion.Euler(new Vector3(60f, 0f, 0f));
        transform.LookAt(playerTransform);
    }
}
