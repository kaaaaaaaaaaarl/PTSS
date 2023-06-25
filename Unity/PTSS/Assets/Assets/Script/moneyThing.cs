using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class moneyThing : MonoBehaviour
{
    public float moneyCash = 0f;
    private string n;
    public TMP_Text MoneyTextObject;
    // Start is called before the first frame update
    void Start()
    {
        MoneyTextObject.text = moneyCash.ToString();
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
        moneyCash += money;
        MoneyTextObject.text = moneyCash.ToString();
    }
    public void removeMoney(float money)
    {
        moneyCash = moneyCash - money;
        MoneyTextObject.text = moneyCash.ToString();
    }

}
