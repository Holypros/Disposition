using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);

    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Hit something");
        Destroy(gameObject, 0f);

    }

}
