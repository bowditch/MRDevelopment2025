//Add component to gnome or chicken GameObject (Agent)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshDisengage : MonoBehaviour
{
    public NavMeshAgent agent;
    public float groundDistance = 0.1f;
    public LayerMask ground;
    private bool isOnGround;
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }
    void GroundCheck()
    {
        isOnGround = Physics.Raycast(transform.position, Vector3.down, groundDistance); //down direction may be flipped - if so, change to Vector3.up

        if (agent != null)
        {
            agent.enabled = isOnGround;
        }
    }
}
