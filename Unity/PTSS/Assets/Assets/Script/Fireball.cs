﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f; // The speed of the fireball
    public float damage = 10f;
    private Transform target; // The current target of the fireball

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Debug.Log("Fireball target: " + target.gameObject.name);

            Vector3 direction = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }
    }

    // Set the target of the fireball
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fireball has collided with an enemy
        if (collision.CompareTag("Pizza"))
        {
            // Damage the enemy
            collision.GetComponent<map1Move>().TakeDamage(damage);

            // Destroy the fireball
            Destroy(gameObject);
            Debug.Log("destroy?");
        }
    }

    // Destroy the fireball when it hits the target
    void HitTarget()
    {
        Destroy(gameObject);
    }
}