using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pathing : MonoBehaviour {

    public float speed;
    public float wait;
    public Transform path;


    void Start () {
        Vector3[] waypoints = new Vector3[path.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = path.GetChild (i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));
    }

    IEnumerator FollowPath(Vector3[] waypoints) {
        transform.position = waypoints[0];

        int targetWaypointindex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointindex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed = Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointindex = (targetWaypointindex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointindex];
                yield return new WaitForSeconds(wait);
            }
            yield return null;
        }
    }	

    private void OnDrawGizmos()
    {
        Vector3 startPosition = path.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in path)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
