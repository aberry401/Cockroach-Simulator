using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Written by Andrew Berry
public class AB_KyleScript : MonoBehaviour
{
    public AndrewPlayerController player;
    public List<Transform> checkpoints;
    public NavMeshAgent human;
    private Transform currentDest;
    private int currentInd = 0;
    private bool chasingRoach = false;
    // Start is called before the first frame update
    void Start()
    {
        human = gameObject.GetComponent<NavMeshAgent>();
        currentDest = checkpoints[currentInd];
        transform.position = checkpoints[currentInd].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasingRoach && human.remainingDistance < 2)
        {
            if(currentInd == 6) 
                currentInd = 0;
            else
                currentInd++;
            currentDest = checkpoints[currentInd];
            human.SetDestination(currentDest.position);
        }

        if (!player.inCover && Vector3.Distance(transform.position, player.transform.position) < 15) 
        {
            if (!chasingRoach)
            {
                player.IsNotEscaping();
                chasingRoach = true;
            }
            human.SetDestination(player.transform.position);
        }

        if (player.inCover)
        {
            if (chasingRoach)
            {
                chasingRoach = false;
                human.SetDestination(checkpoints[currentInd].position);
            }
        }
    }

    public bool isChasing()
    {
        return chasingRoach;
    }
}
