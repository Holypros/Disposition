using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] public TimeTravel timeTravel;
    [SerializeField] public ShootingAiTut enemyAI;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWorldOne" && timeTravel.isWorldOneActive)
        {
            other.GetComponent<ShootingAiTut>().TakeDamage(20);
            Debug.Log("enemy 1 hit");
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            // get component enemy health
            // decrease enemy health
        }
        else if (other.tag == "EnemyWorldTwo" && timeTravel.isWorldTwoActive)
        {
            Debug.Log("enemy 2 hit");
            other.GetComponent<ShootingAiTut>().TakeDamage(20);
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

            // get component enemy health
            // decrease enemy health
        }
        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

    }
}
