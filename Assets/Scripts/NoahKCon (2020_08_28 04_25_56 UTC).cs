using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NoahKCon : MonoBehaviour
{
    private NavMeshAgent Knav;
    public GameObject playerPos;
    // Start is called before the first frame update
    void Start()
    {
        Knav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Knav.SetDestination(playerPos.transform.position);
    }
}
