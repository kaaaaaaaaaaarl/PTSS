using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public int numClones = 0;
    public float timeBetweenClones = 0;
    public GameObject clonePrefab;
    public GameObject scriptToAdd;

    private bool isClone = false;

    void Start()
    {
        if (transform.parent != null)
        {
            isClone = true;
        }

        if (!isClone)
        {
            for (int i = 0; i < numClones; i++)
            {
                StartCoroutine(SpawnClone());
            }
        }
    }

    IEnumerator SpawnClone()
    {
        for (int i = 0; i < numClones; i++)
        {
            // Wait for specified time before spawning clone
            yield return new WaitForSeconds(timeBetweenClones);


            GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);
            clone.transform.parent = transform;

            if (scriptToAdd != null)
            {
                clone.AddComponent(scriptToAdd.GetType());
            }
        }
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(timeBetweenClones);
    }
}