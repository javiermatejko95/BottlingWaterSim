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
    private bool walkingToEnd;

    private WAYPOINT currentWaypoint;

    private void Awake()
    {
        waitingForBottle = false;
        walkingToEnd = false;

        SetSpawnPoint();
    }

    private void Update()
    {
        if(agent.remainingDistance > agent.stoppingDistance || agent.pathPending)
        {
            return;
        }

        if (!waitingForBottle && currentWaypoint == WAYPOINT.STAND)
        {
            TryTakeBottle();
        }

        if(currentWaypoint == WAYPOINT.END)
        {
            if(Vector3.Distance(agent.transform.position, GetWaypoint(WAYPOINT.END).waypoint.position) <= 1)
            {
                SetSpawnPoint();
            }
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
        currentWaypoint = WAYPOINT.SPAWN_POINT;

        agent.transform.position = GetWaypoint(WAYPOINT.SPAWN_POINT).waypoint.position;

        SetStandPoint();

        walkingToEnd = false;
    }

    private void SetStandPoint()
    {
        currentWaypoint = WAYPOINT.STAND;

        agent.SetDestination(GetWaypoint(WAYPOINT.STAND).waypoint.position);
    }

    private void SetEndPoint()
    {
        currentWaypoint = WAYPOINT.END;

        agent.SetDestination(GetWaypoint(WAYPOINT.END).waypoint.position);
        waitingForBottle = false;
        walkingToEnd = true;
    }

    private Waypoint GetWaypoint(WAYPOINT newWaypoint)
    {
        return waypoints.First(w => w.waypointPoint == newWaypoint);
    }

    private void GrabBottle()
    {
        SetEndPoint();
        bottleHolder.GrabBottle();

        MoneyManager.Instance.UpdateMoney(10);
        CustomersManager.Instance.AddCustomers(1);
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