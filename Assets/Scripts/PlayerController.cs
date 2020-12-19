using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController playerController;

    public bool firstPerson = true;

    public float speed = 6f;

    private void Update()
    {
        if (Input.GetKey("f1"))
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
                move = new Vector3(x, 0f, z);
                ThirdPersonUpdate(move);
                break;
        }
    }

    void FirstPersonUpdate(Vector3 moveVector)
    {
        playerController.Move(moveVector * speed * Time.deltaTime);
    }

    void ThirdPersonUpdate(Vector3 moveVector)
    {

    }
}
