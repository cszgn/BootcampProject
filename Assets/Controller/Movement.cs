using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody capsuleRg;
    public Vector2 moveVal;
    public float moveSpeed = 5;

    private void Awake()
    {
        capsuleRg = GetComponent<Rigidbody>();
    }

    public void Moving(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
             moveVal = value.ReadValue<Vector2>();
            //capsuleRg.AddForce(new Vector3(moveVal.x * moveSpeed, 0f, moveVal.y * moveSpeed));
        }

        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }

}
