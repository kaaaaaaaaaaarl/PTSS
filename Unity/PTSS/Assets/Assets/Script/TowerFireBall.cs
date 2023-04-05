using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerFireBall : MonoBehaviour
{
    public float range = 5f;
    public float fireRate = 0.5f;
    public GameObject fireballPrefab;

    private Transform pizzaTransform;
    private float nextFireTime;

    void Start()
    {
        pizzaTransform = GameObject.FindGameObjectWithTag("Pizza").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pizzaTransform.position) <= range && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().velocity = (pizzaTransform.position - transform.position).normalized * fireball.GetComponent<fireball>().speed;
    }
}