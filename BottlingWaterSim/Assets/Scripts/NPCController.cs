using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Waypoint[] waypoints;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private BottleHolder bottleHolder;

    private bool waitingForBottle;

    private WAYPOINT waypoint_status;

    private void Awake()
    {
        waitingForBottle = false;

        SetSpawnPoint();
    }

    private void Update()
    {
        if(agent.remainingDistance > agent.stoppingDistance)
        {
            return;
        }

        if (!waitingForBottle && waypoint_status == WAYPOINT.STAND)
        {
            TryTakeBottle();
        }

        if(waypoint_status == WAYPOINT.END)
        {
            SetSpawnPoint();
        }
    }

    private void TryTakeBottle()
    {
        if (bottleHolder.HasActiveBottle())
        {
            GrabBottle();
        }
        else
        {
            Debug.Log("Esperando botellas...");
            waitingForBottle = true;
            bottleHolder.SuscribeToAction(WaitGrabBottle);
        }
    }

    private void SetSpawnPoint()
    {
        waypoint_status = WAYPOINT.SPAWN_POINT;

        agent.transform.position = GetWaypoint(WAYPOINT.SPAWN_POINT).waypoint.position;
        SetStandPoint();
    }

    private void SetStandPoint()
    {
        waypoint_status = WAYPOINT.STAND;

        agent.SetDestination(GetWaypoint(WAYPOINT.STAND).waypoint.position);
    }

    private void SetEndPoint()
    {

        waitingForBottle = false;
        agent.SetDestination(GetWaypoint(WAYPOINT.END).waypoint.position);
        waypoint_status = WAYPOINT.END;
    }

    private Waypoint GetWaypoint(WAYPOINT newWaypoint)
    {
        return waypoints.First(w => w.waypointPoint == newWaypoint);
    }

    private void GrabBottle()
    {
        SetEndPoint();
        bottleHolder.GrabBottle();
    }

    private void WaitGrabBottle()
    {
        GrabBottle();

        bottleHolder.UnsuscribeToAction(WaitGrabBottle);
    }
}

[Serializable]
public struct Waypoint
{
    public WAYPOINT waypointPoint;
    public Transform waypoint;
}

public enum WAYPOINT
{
    SPAWN_POINT,
    STAND,
    END
}