using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenShop : MonoBehaviour
{
    public GameObject ovenPrefab;
    public GameObject moneythingy;
    public float OvenPrice;

    private float StartPositionY;
    private float StartPositionX;
    private Vector3 myVector;
    void Start()
    {
        StartPositionY = this.transform.position.y;
        StartPositionX = this.transform.position.x;
        myVector = new Vector3(StartPositionX, StartPositionY, 0.0f);
    }

    private void OnMouseDown()
    {
        Debug.Log("pressed");
        if (moneythingy.GetComponent<moneyThing>().moneyCash >= OvenPrice) {
            moneythingy.GetComponent<moneyThing>().removeMoney(OvenPrice);
            GameObject furnaceOBJ = Instantiate(ovenPrefab, transform.position += Vector3.left, Quaternion.identity);
            transform.position = myVector;
            furnaceOBJ.transform.SetParent(moneythingy.transform);
            

        }
    }
}
