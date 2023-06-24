using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot2 : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 20f;
    public float fireRate = 1f;
    public float range = 5f;

     public Transform target;
    private float fireCountdown = 0f;
    public List<GameObject> colliderList = new List<GameObject>();
    //runs all the shi

    private void Start()
    {

        fireballPrefab = GameObject.Find("FireBall");
        GameObject fireballGO = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireballGO.transform.SetParent(this.gameObject.transform);
    }
    void Update()
    {
        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
        if (this.gameObject.transform.childCount <1) {
            fireballPrefab = GameObject.Find("FireBall");
            GameObject fireballGO = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            fireballGO.transform.SetParent(this.gameObject.transform);
        }
    }
    //checks local pizzas and places in a list
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!colliderList.Contains(collider.gameObject) && collider.gameObject.name== "pngegg(Clone)")
        {
            colliderList.Add(collider.gameObject);
            if (collider.gameObject.name != "FireBall" || collider.gameObject.name != "FireBall (clone)")
            {
                target = collider.gameObject.transform;
            }
        }
    }
    //destroys a fireball
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (colliderList.Contains(collider.gameObject))
        {
            colliderList.Remove(collider.gameObject);
        }
    }
  //shooting a target at the neerest pizza
    void Shoot()
    {
        if (target != null) {
            
            GameObject fireballGO = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = fireballGO.GetComponent<Rigidbody2D>();
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * fireballSpeed;
        }
    }

    public Transform GetTarget() {
        return (target);
    }
}