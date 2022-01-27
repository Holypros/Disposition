using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] Transform targetTransform;
    [SerializeField] Transform cameraPivot;
    public Transform cameraTransform;

    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    private Vector3 cameraVectorPosition;
    public LayerMask collisionLayers;

    public float cameraCollisionOffset = 0.2f;
    public float minimumCollisionOffset = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    [SerializeField] float cameraFollowSpeed = 0.2f;
    [SerializeField] float cameraSmooth = 0.5f;
    //[SerializeField] float cameraPivotSpeed = 0.5f;

    [SerializeField] float lookAngle;
    [SerializeField] float pivotAngle;
    public float minimumPivotAngle = -25;
    public float maxiumPivotAngle = 25;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }
    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.cameraInputX );
        pivotAngle = pivotAngle - (inputManager.cameraInputY );
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maxiumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSmooth);
        transform.rotation = targetRotation;
       targetRotation.Normalize();


        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        targetRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, cameraSmooth);
        cameraPivot.localRotation = targetRotation;
        targetRotation.Normalize();

    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition),collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
            targetPosition = targetPosition - minimumCollisionOffset;

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
