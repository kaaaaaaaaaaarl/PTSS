using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public bool paused = false;
    public GameObject PauseMenu;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnMouseDown()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
        else 
        {
            paused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        
    }
}
