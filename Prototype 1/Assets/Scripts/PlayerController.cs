using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    private Rigidbody playerRb;

    public FollowPlayer cameraScript;

    [SerializeField] private float horsePower = 20f;
    [SerializeField] private float turnSpeed;

    private float horizontalInput;
    private float forwardInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

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


    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        Debug.Log(Vector3.forward * forwardInput * horsePower);
    }
}
