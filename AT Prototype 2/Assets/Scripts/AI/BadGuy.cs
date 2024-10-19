using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BadGuy : MonoBehaviour
{
    public Transform[] waypoints; 
    private NavMeshAgent agent;
    private GameObject CurrentTarget;
    private int CurrentWaypoint = 0;
    private int Health = 4;
    private enum BadGuyStates
    {
        Patrol,
        Hunting
    }
    private BadGuyStates currentState = BadGuyStates.Patrol;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(waypoints[CurrentWaypoint].position);
        CurrentWaypoint++;
        agent.SetDestination(waypoints[CurrentWaypoint].position);
    }


    private void Update()
    {

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

        switch (currentState) {
            case BadGuyStates.Patrol:
                Patrol();
                break;
            case BadGuyStates.Hunting:
                Hunting();
                break;
    }
}

    private void SetNextWaypoint()
    {
        CurrentWaypoint++;
        CurrentWaypoint %= waypoints.Length;
        agent.SetDestination(waypoints[CurrentWaypoint].position);
    }

    private void SwitchState(BadGuyStates newState)
    {
        switch (newState)
        {
            case BadGuyStates.Patrol:
                currentState = newState;
                agent.SetDestination(CurrentTarget.transform.position);
                break;
            case BadGuyStates.Hunting:
                currentState = newState;
                break;
        }
    }

    private void Hunting()
    {
        agent.SetDestination(CurrentTarget.transform.position);
    }

    private void Patrol()
    {
        if (agent.remainingDistance < agent.velocity.magnitude)
        {
            SetNextWaypoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CurrentTarget != other.gameObject)
        {
            CurrentTarget = other.gameObject;
            SwitchState(BadGuyStates.Hunting);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CurrentTarget = null;
            SwitchState(BadGuyStates.Patrol);
        }
    }


    public void OnHit()
    {
        Health--;
    }

}

