using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map1Move : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public float minDistance = 0.1f;

    private int currentWaypoint = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < minDistance)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                // If we have reached the last waypoint, create a new clone of the enemy and destroy this one
                Instantiate(gameObject, waypoints[0].position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        Vector2 direction = (waypoints[currentWaypoint].position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}