using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints;

    public Waypoint defaultWaypoint;

    void Start()
    {
        Debug.Log(waypoints.Count.ToString());
    }

    public Waypoint GetVacantWaypoint()
    {
        Debug.Log(waypoints.Count.ToString());
        if (waypoints.Count > 0)
        {
            Waypoint waypointToReturn = waypoints[0];
            waypoints.Remove(waypoints[0]);

            return waypointToReturn;
        }

        return defaultWaypoint;
    }
}
