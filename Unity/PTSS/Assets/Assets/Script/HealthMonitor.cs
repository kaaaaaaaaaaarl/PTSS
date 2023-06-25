using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    public int health;
    public void addHealth (int healthBack)
    {
        health = health + healthBack;
    }
    public void removeHealth(int dammage)
    {
        health = health - dammage;
    }
}
