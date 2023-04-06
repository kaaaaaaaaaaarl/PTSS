using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot2 : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public float fireRate = 2f;
    public float range = 5f;

    private Transform target;
    private float fireCountdown = 0f;

    void Update()
    {
        FindTarget();

        if (target == null)
            return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Pizza");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject fireballGO = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = fireballGO.GetComponent<Rigidbody2D>();
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * fireballSpeed;
    }
}
