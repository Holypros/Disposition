using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]  float mouseSens = 800f;

    [SerializeField] Transform playerBody;

    private float xRot = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //to hide cursor in game
    }

    void Update()
    {
        #region MouseInput
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime; 
        #endregion

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);        //Clamping Values for vertical rotation so that character can't look 180 deg


        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
