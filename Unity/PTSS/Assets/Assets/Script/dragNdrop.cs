
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class dragNdrop : MonoBehaviour
{
    //things that can be chainged
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

        public bool canPlace = true;
        private SpriteRenderer rend;
        private CircleCollider2D circleCollider;


        private RectTransform rectTransform;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();

            circleCollider = GetComponent<CircleCollider2D>();
            if (gameObject.name.Contains("Clone"))
            {
                transform.SetParent(moneythingy.transform);
            }
        circleCollider.radius = 0.7f;


    }
        void Update()
        {
            if (isBeingHeld == true)
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

        private void OnMouseDown()
        {

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


            if (transform.position.x >6.2f)
            {
                // rend = GetComponent<SpriteRenderer>();
                //rend.color = CantPlaceColor;
                this.gameObject.transform.localPosition = new Vector3(sstartposX, sstartposY, 0);
                Destroy(this.gameObject);
            }
            else
            {
                isBeingHeld = false;
                circleCollider.radius = 2f;
                transform.SetParent(turret.transform);
            }
        }


        void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.name == "Shop")
            {
                canPlace = false;
            }
            else {
                canPlace = true;
            }
        }


        void OnTriggerExit2D(Collider2D col)
        {
            if (col.name == "Shop")
            {
                
                canPlace = true;
            }
        }
    }
