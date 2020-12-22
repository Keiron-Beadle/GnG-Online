using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameCameras : MonoBehaviour
{
    public PlayerController playerController;
    public CameraController cameraController;

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByName("SampleScene").isLoaded)
        {
            playerController.enabled = true;
            cameraController.Enable();
            cameraController.enabled = true;
        }
        else
        {
            playerController.enabled = false;
            cameraController.Disable();
            cameraController.enabled = false;
        }
    }
}
