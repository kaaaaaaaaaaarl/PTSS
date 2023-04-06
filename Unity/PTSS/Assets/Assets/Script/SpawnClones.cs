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

    private float nextFireTime;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(timeBetweenClones);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime) {
            GameObject spawnedClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            nextFireTime = Time.time + timeBetweenClones;
        }
    }
}
