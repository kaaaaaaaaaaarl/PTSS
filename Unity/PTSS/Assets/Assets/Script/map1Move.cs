using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map1Move : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public float minDistance = 0.1f;
    public float health = 10f;

    private int currentWaypoint = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < minDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            if (currentWaypoint == 0)
            {
                Destroy(gameObject);
            }
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
        if (gameObject.activeSelf) {
            Vector2 direction = (waypoints[currentWaypoint].position - transform.position).normalized;
            rb.velocity = direction * speed;
        } 
    }

    internal void TakeDamage(float damage)
    {
        health = health - damage;
    }

}