using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClones : MonoBehaviour
{
    public int numClones = 0;
    public float timeBetweenClones = 0f;
    public GameObject enemyPrefab;
    public Transform[] waypoints;
    public float timzz = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numClones; i++)
        {
            
            // Spawn a new clone
            GameObject spawnedClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Add a WaypointFollower component to the clone and set its waypoints

            // Wait before spawning the next clone
            StartCoroutine(WaitAndSpawn());
        }
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(timeBetweenClones);
    }

    // Update is called once per frame
    void Update()
    {
        timzz = Time.realtimeSinceStartup;
    }
}
