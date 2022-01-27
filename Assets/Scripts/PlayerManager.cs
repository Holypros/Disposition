using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocoMotions playerLocoMotions;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocoMotions = GetComponent<PlayerLocoMotions>();

    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        playerLocoMotions.HandleAllMovements();
        cameraManager.HandleAllCameraMovement();

    }


}
