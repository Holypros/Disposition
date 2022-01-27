using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speed = 1f, destroyAfter = 5f;
        void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, destroyAfter);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        Destroy(gameObject, 0.5f);
    }
}
