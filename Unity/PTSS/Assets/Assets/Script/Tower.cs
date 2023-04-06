using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 10f; // The range of the tower's attack
    public float attackSpeed = 1f; // The speed at which the tower attacks
    public GameObject projectilePrefab; // The prefab for the tower's projectile

    private float timeSinceLastAttack; // The time since the tower last attacked

    // Update is called once per frame
    void Update()
    {
        // Find all enemies within range
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            Debug.Log("EnemyFound");
            // Check if the collider is an enemy
            map1Move enemy = collider.GetComponent<map1Move>();
            if (enemy != null)
            {
                // Check if enough time has passed since the tower last attacked
                if (Time.time - timeSinceLastAttack >= 1 / attackSpeed)
                {
                    // Attack the enemy by shooting a fireball
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Fireball>().SetTarget(enemy.transform);
                    timeSinceLastAttack = Time.time;
                }
            }
        }
    }

    // Draw a sphere around the tower in the Scene view to show its range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}