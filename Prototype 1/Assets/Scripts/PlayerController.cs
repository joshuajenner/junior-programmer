using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    public FollowPlayer cameraScript;

    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnSpeed;

    private float horizontalInput;
    private float forwardInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        horizontalInput = inputValue.x;
        forwardInput = inputValue.y;
        
    }

    public void OnToggleCamera(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            cameraScript.TogglePosition();
        }
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
