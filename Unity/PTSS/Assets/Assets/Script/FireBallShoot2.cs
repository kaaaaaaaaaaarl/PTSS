using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 2f;

    private bool isClone;

    void Start()
    {
        // Check if this object is a clone
        isClone = transform.parent != null && transform.parent.name.Contains("(Clone)");

        // Destroy the original object if it's not a clone
        if (!isClone)
        {
            Destroy(gameObject);
        }
        else
        {
            // Set the lifetime of the clone
            Destroy(gameObject, lifetime);
        }
    }

    void Update()
    {
        // Move the fireball forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fireball has collided with an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Damage the enemy
            collision.GetComponent<map1Move>().TakeDamage(damage);

            // Destroy the fireball
            Destroy(gameObject);
        }
    }
}