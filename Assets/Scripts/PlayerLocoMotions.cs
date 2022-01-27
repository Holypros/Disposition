using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocoMotions : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7;
    public float rotationSpeed = 15;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    public void HandleAllMovements()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDIrection = Vector3.zero;
        targetDIrection = cameraObject.forward * inputManager.verticalInput;
        targetDIrection = targetDIrection + cameraObject.right * inputManager.horizontalInput;
        targetDIrection.Normalize();
        targetDIrection.y = 0;

        if (targetDIrection == Vector3.zero)
            targetDIrection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDIrection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
