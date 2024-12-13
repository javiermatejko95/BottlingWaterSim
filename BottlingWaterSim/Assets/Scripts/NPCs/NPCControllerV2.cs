using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerV2 : MonoBehaviour
{
    [SerializeField] private NPC[] npcs;
    [SerializeField] private float updateRate = 0.1f;

    [SerializeField] private Transform startingPosition;

    [SerializeField] private Transform[] waypoints;

    private Queue<NPC> npcQueue;

    private void Awake()
    {
        npcQueue = new Queue<NPC>(npcs.Length);
    }

    private void Update()
    {
        
    }

    private void CheckNPC()
    {
        NPC npc = npcs[0];

        if(npc.Status == WAYPOINT_STATUS.INACTIVE)
        {
            npc.SetStartingPosition(startingPosition.position);
            npc.SetActive(true);
            npc.SetNextWaypoint(waypoints[0].position);
            return;
        }
    }
}


public enum WAYPOINT_STATUS
{
    INACTIVE,
    MOVING,
    IN_QUEUE,
    WAITING_INTERACTION,
    INTERACTING
}

[Serializable]
public struct QueuePosition
{
    public Transform position;
}