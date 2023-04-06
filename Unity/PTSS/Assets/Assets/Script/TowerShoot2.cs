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
    private float fireCountdown = 5f;
    public List<GameObject> colliderList = new List<GameObject>();

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!colliderList.Contains(collider.gameObject) && collider.gameObject.name== "pngegg(Clone)")
        {
            colliderList.Add(collider.gameObject);
            if (collider.gameObject.name != "FireBall" || collider.gameObject.name != "FireBall (clone)" || Time.time >= fireCountdown)
            {
                target = collider.gameObject.transform;
                Shoot();
                fireCountdown = fireRate + Time.time;
                Debug.Log(fireCountdown);
                Debug.Log(Time.time);
            }

        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (colliderList.Contains(collider.gameObject))
        {
            colliderList.Remove(collider.gameObject);

        }
    }

    void FindTarget()
    {

   
    }

    void Shoot()
    {
        GameObject fireballGO = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = fireballGO.GetComponent<Rigidbody2D>();
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * fireballSpeed;
    }
}
