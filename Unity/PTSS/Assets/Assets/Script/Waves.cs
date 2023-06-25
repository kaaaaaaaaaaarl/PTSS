using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int dificulty = 1;
    public GameObject SpawnCL;

    private float time;
    private float timeBetweenDificulty = 40;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenDificulty = timeBetweenDificulty / dificulty;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        time += timeBetweenDificulty;
        time =  timeBetweenDificulty/ time;
        SpawnCL.GetComponent<SpawnClones>().timeBetweenClones = time;





    }
}
