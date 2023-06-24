using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moneyThing : MonoBehaviour
{
    public float moneyCash = 0f;
    private string n;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        switch (this.gameObject.transform.Find(n))
        {
            case n==:
                Console.WriteLine("Monday");
                break;

        }
        */
    }
    public void addMoney( float money) {
        moneyCash = moneyCash + money;
    }
    public void removeMoney(float money)
    {
        moneyCash = moneyCash - money;
    }

}
