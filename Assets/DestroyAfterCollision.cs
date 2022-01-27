using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{

private void OnCollisionEnter(Collision other) 
{
    Destroy(gameObject,0f);
}

}
