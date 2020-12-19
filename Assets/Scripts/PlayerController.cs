using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController playerController;

    public bool firstPerson = true;

    public float speed = 6f;

    private bool firstPersonLast;

    private void Update()
    {
        bool firstPersonCurrent = Input.GetKey("f1");
        if (firstPersonCurrent && !firstPersonLast)
        {
            firstPerson = !firstPerson;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = Vector3.zero;
        switch (firstPerson)
        {
            case true:
                move = transform.right * x + transform.forward * z;
                FirstPersonUpdate(move);
                break;
            case false:
                move = new Vector3(-z, 0f, x);
                ThirdPersonUpdate(move);
                break;
        }
        firstPersonLast = firstPersonCurrent;
    }

    void FirstPersonUpdate(Vector3 moveVector)
    {
        playerController.Move(moveVector * speed * Time.deltaTime);
    }

    void ThirdPersonUpdate(Vector3 moveVector)
    {
        playerController.Move(moveVector * speed * Time.deltaTime);

        float rotation = 0f;

        if (moveVector.x < 0 && moveVector.z < 0)
        {
            rotation = 225;
        }
        else if (moveVector.x > 0 && moveVector.z < 0)
        {
            rotation = 135;
        }
        else if (moveVector.x < 0 && moveVector.z > 0)
        {
            rotation = 315;
        }
        else if (moveVector.x > 0 && moveVector.z > 0)
        {
            rotation = 45;
        }
        else if (moveVector.x < 0)
        {
            rotation = 270;
        }
        else if (moveVector.x > 0)
        {
            rotation = 90;
        }
        else if (moveVector.z < 0)
        {
            rotation = 180;
        }
        else if (moveVector.z > 0)
        {
            rotation = 360;
        }

        if (rotation != 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }
    }
}
