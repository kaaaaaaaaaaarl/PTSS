
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class dragNdrop : MonoBehaviour
{//things that can be chainged
    public int price = 0;
    public bool InShop = false;
    public GameObject moneythingy;
    //movement stuff
    private float startposX;
    private float startposY;
    //bug fixing stuff
    public float sstartposX;
    public float sstartposY;
    private bool isBeingHeld = false;
    public Color CantPlaceColor;
    public GameObject turret;
    public GameObject furnaceThing;
    
    private bool canPlace = true;
    private SpriteRenderer rend;
    private CircleCollider2D circleCollider;


    void Start()
    {
        
        circleCollider = GetComponent<CircleCollider2D>();
        if (gameObject.name.Contains("Clone"))
        {
            transform.SetParent(moneythingy.transform);
        }
        

    }
    void Update() { 
        if(isBeingHeld == true) 
        {
            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startposX, mousePos.y - startposY, 0);
            /*
            if (canPlace)
            {
                rend = GetComponent<SpriteRenderer>();
                rend.color = CantPlaceColor;
            }*/
        }
    }
    
    private void OnMouseDown() {
        
        if (Input.GetMouseButtonDown(0) && transform.parent.ToString().Contains("MONEY")
            )
        {
            
            transform.SetParent(turret.transform);

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startposX = mousePos.x - this.transform.localPosition.x;
            startposY = mousePos.y - this.transform.localPosition.y;

            sstartposX = this.transform.localPosition.x;
            sstartposY = this.transform.localPosition.y;
            

            circleCollider.radius = 0.7f;
            isBeingHeld = true;
        }
    }
    
    private void OnMouseUp()
    {
        isBeingHeld = false;
        
        if (!canPlace) {
           // rend = GetComponent<SpriteRenderer>();
            //rend.color = CantPlaceColor;
            this.gameObject.transform.localPosition = new Vector3(sstartposX, sstartposY, 0);
            Destroy(this.gameObject);
        }
        else {
            isBeingHeld = false;
            circleCollider.radius = 2f;
            transform.SetParent(turret.transform);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (this.transform.parent.ToString().Contains("MONEY"))
        {
            Debug.Log("cant place");
            canPlace = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (this.transform.parent.ToString().Contains("MONEY") && col.transform.name == "Shop")
        {
            Debug.Log("can place");
            canPlace = false;
        }
    }  
}
