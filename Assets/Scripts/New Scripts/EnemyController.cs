using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] NavMeshAgent navMesh;
    [SerializeField] float chasingDistance = 20;
    [SerializeField] float originalPosOffset =0.3f;
    [SerializeField] Vector3 originalPos;
    [SerializeField] float attackingDistance = 10f;
    [SerializeField] Projectiles enemyBullet;
    [SerializeField] float coolDownTime = 4f, nextFireTime = 0f;
    void Start()
    {
        originalPos = transform.position;
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetDistanceFromPlayer()<=chasingDistance  && GetDistanceFromPlayer()> attackingDistance)
        {
            navMesh.isStopped = false;

            transform.LookAt(player.transform);
            navMesh.SetDestination(player.transform.position);
        }
        else if (GetDistanceFromPlayer() > attackingDistance)
        {
            navMesh.isStopped = true;
            StartAttacking();
        }
        else
        {
            if(GetDistanceFromOriginalPosition()>= originalPosOffset)
            {
                navMesh.isStopped = false;
                navMesh.SetDestination(originalPos);
            }

        }
    }
    private void StartAttacking()
    {
        if(nextFireTime<Time.time)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            nextFireTime = coolDownTime + Time.time;
        }
    }
    float GetDistanceFromOriginalPosition()
    {
        return Vector3.Distance(transform.position,originalPos);

    }
    float GetDistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingDistance);
    }
}
