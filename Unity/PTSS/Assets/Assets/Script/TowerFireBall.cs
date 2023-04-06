using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerFireBall : MonoBehaviour
{
    public float range = 20f;
    public float fireRate = 5f;
    public GameObject fireballPrefab;
    public float TimeRN;

    private Transform pizzaTransform;
    public float nextFireTime;

    void Start()
    {
        pizzaTransform = GameObject.FindGameObjectWithTag("Pizza").transform;

    }

    void Update()
    {
        TimeRN = Time.time;
        if (Vector3.Distance(transform.position, pizzaTransform.position) <= range)
        if (Time.time >= nextFireTime) {
             {
                    Fire();
                    nextFireTime = Time.time + fireRate;
                   

             }
        }
    }

    void Fire()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        
    }
}