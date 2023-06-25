using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverBar;
    public GameObject HealthMonitor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.name  == gameOverBar.name) {
            Debug.Log("dammage delt");
            //moneythingy.GetComponent<moneyThing>().removeMoney(OvenPrice);
            HealthMonitor.GetComponent<HealthMonitor>().removeHealth(1);

        }
    }
    }
