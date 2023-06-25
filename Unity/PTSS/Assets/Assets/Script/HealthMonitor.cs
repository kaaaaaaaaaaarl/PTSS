using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthMonitor : MonoBehaviour
{
    public int health;
    public GameObject GameOverScreen;
    public TMP_Text HealthValue;
    public void addHealth (int healthBack)
    {
        health = health + healthBack;
    }
    public void removeHealth(int dammage)
    {
        health = health - dammage;
        if(health<= 0)
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        HealthValue.text = ("health: " + health.ToString());
    }
    private void Start()
    {
        HealthValue.text = ("health: " + health.ToString());
    }

}
