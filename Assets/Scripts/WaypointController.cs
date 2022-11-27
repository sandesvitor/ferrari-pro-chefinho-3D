using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints;
    private Waypoint startingWaypoint;

    public Waypoint GetVacantWaypoint()
    {
        if (waypoints.Count > 0)
        {
            Waypoint waypointToReturn = waypoints[0];
            waypoints.Remove(waypoints[0]);

            return waypointToReturn;
        }

        return startingWaypoint;
    }
}
