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
        playerHealth = 1000f;
    }
    void Update() 
    {
        if(playerHealth <= 0)
        {
            isPlayerAlive = false;
            animator1.SetBool("isDead",true);
            animator2.SetBool("isDead",true);
            //Play dead animation
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
}
