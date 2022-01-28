using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletProj;
    [SerializeField] private Transform spawnBulletPosition;

    float time = 0f;


    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInput;

    private void Awake()
    {
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInput.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection= (worldAimTarget-transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime* 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            if(time < Time.time)
            {
                thirdPersonController.SetRotateOnMove(true);
            }
            
           
        }

        if (starterAssetsInput.shoot)
        {
            time = Time.time + 1;
            Vector3 aimDir  = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection= (worldAimTarget-transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime* 1000f);
            thirdPersonController.SetRotateOnMove(false);
            Transform bulletGame = Instantiate(bulletProj, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bulletGame.GetComponent<BulletHit>().timeTravel = GetComponent<TimeTravel>();
            starterAssetsInput.shoot = false;
        }
       
    }
    


      
}

