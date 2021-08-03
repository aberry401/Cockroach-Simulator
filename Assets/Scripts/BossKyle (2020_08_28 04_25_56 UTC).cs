using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossKyle : MonoBehaviour
{
    public GameObject player;
    public bool attacking;
    public NavMeshAgent nav;
    private float recovery = 5f;
    private float timeNow;
    private float timeToGet;
    private bool hasAttacked;


    private void Start()
    {
        timeNow = Time.time;
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(attacking == true)
        {
            nav.isStopped = true;
            attacking = false;
            timeToGet = Time.time + recovery;
            hasAttacked = false;
        }
        else if(timeNow >= timeToGet && hasAttacked == false)
        {
            nav.isStopped = false;
            Explode();
            hasAttacked = true;
        }
        else
        {
            timeNow += Time.deltaTime;
        }
        nav.SetDestination(player.transform.position);
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            attacking = true;
        }
    }


    private void Explode()
    {


    }

}
