using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public bool paused = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
    private void OnMouseDown()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
        }
        else 
        {
            paused = true;
            Time.timeScale = 0;
        }
        
    }
}
