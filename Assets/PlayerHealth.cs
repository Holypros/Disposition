using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public bool isPlayerAlive = true;
    public Animator animator1;
    public Animator animator2;
    void Start() 
    {
        playerHealth = 100f;
    }
    void Update() 
    {
        if(playerHealth <= 0)
        {
            isPlayerAlive = false;
            //Play dead animation
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
}
