using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private WAYPOINT_STATUS status;
    [SerializeField] private NavMeshAgent agent;

    private Vector3 currentWaypointPosition;

    public WAYPOINT_STATUS Status { get => status; }

    public void SetNextWaypoint(Vector3 nextWaypointPosition)
    {
        currentWaypointPosition = nextWaypointPosition;

        agent.SetDestination(currentWaypointPosition);
    }

    public void SetStatus(WAYPOINT_STATUS status)
    {
        this.status = status;
    }

    public void SetActive(bool status)
    {
        gameObject.SetActive(status);
    }

    public void SetStartingPosition(Vector3 startingPosition)
    {
        this.transform.position = startingPosition;
    }
}
