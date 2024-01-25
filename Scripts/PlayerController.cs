using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed;
    public GameObject ground;
    //private bool isJumping;
    private float jumpForce;
    private GameObject orange;
    private GameObject yellow;
    private GameObject green;
    private GameObject blue;
    private GameObject red;
    public GameObject fruits;
    private GameObject basket;

    private float offset1;
    private float offset2;

    private int contadorFruta;

    public GameObject catCreator;
    private GameObject catClon;
    public GameObject cat;

    private bool limitR;
    private bool limitL;

    public GameObject fruitSound;


    void Start()
    {
        speed = 3.0f;
        //isJumping = false;
        jumpForce = 7.0f;
        orange = (GameObject)GameObject.Find("Orange");
        yellow = (GameObject)GameObject.Find("Yellow");
        blue = (GameObject)GameObject.Find("Blue");
        green = (GameObject)GameObject.Find("Green");
        red = (GameObject)GameObject.Find("Red");

        basket = (GameObject)GameObject.Find("Basket");

        offset1 = 0.5f; ;
        offset2 = 0.8f;

        contadorFruta = 0;

        limitL = false;
        limitR = false;

    }
  
    void Update()
    {
        if (!General.bloqPlayer)
        {
            horizontal = speed * Time.deltaTime * Input.GetAxis("Horizontal");

            if (General.bloqGround)
            {
                this.gameObject.GetComponent<Transform>().Translate(horizontal, 0.0f, 0.0f);
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0.0f && !limitR)
                {
                    ground.gameObject.GetComponent<Transform>().Translate(-horizontal, 0.0f, 0.0f);
                }
                else if (Input.GetAxis("Horizontal") < 0.0f && !limitL)
                {
                    ground.gameObject.GetComponent<Transform>().Translate(-horizontal, 0.0f, 0.0f);

                }
            }


            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 1);

            }
            else if (Input.GetAxis("Horizontal") < 0.0f)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 2);

            }
            else
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);

            }
        }
        if (contadorFruta == 5)
        {
            Fungus.Flowchart.BroadcastFungusMessage("FullBasket");
        }

    }

    public void DesbloqPlayer()
    {
        General.bloqPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cat")
        {
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;
            Fungus.Flowchart.BroadcastFungusMessage("Dialogue1");
            General.bloqGround = false;

        }

        if (other.gameObject.name == "Orange")
        {
            Fungus.Flowchart.BroadcastFungusMessage("NextFruit1");
            fruits.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            fruits.gameObject.GetComponent<Transform>().GetChild(1).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Transform>().position = new Vector2(basket.gameObject.GetComponent<Transform>().position.x - offset1, basket.gameObject.GetComponent<Transform>().position.y);
            contadorFruta++;
            fruitSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;
        }
        if (other.gameObject.name == "Yellow")
        {
            Fungus.Flowchart.BroadcastFungusMessage("NextFruit2");
            fruits.gameObject.GetComponent<Transform>().GetChild(2).gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            fruits.gameObject.GetComponent<Transform>().GetChild(3).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            fruits.gameObject.GetComponent<Transform>().GetChild(4).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Transform>().position = new Vector2(basket.gameObject.GetComponent<Transform>().position.x + offset1, basket.gameObject.GetComponent<Transform>().position.y);
            contadorFruta++;
            fruitSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;

        }
        if (other.gameObject.name == "Blue")
        {
            Fungus.Flowchart.BroadcastFungusMessage("NextFruit4");
            fruits.gameObject.GetComponent<Transform>().GetChild(5).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            fruits.gameObject.GetComponent<Transform>().GetChild(6).gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Transform>().position =new Vector2(basket.gameObject.GetComponent<Transform>().position.x,basket.gameObject.GetComponent<Transform>().position.y);
            contadorFruta++;
            fruitSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;


        }

        if (other.gameObject.name == "Green")
        {
            Fungus.Flowchart.BroadcastFungusMessage("NextFruit3");
            fruits.gameObject.GetComponent<Transform>().GetChild(7).gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            fruits.gameObject.GetComponent<Transform>().GetChild(8).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Transform>().position = new Vector2(basket.gameObject.GetComponent<Transform>().position.x - offset2, basket.gameObject.GetComponent<Transform>().position.y);
            contadorFruta++;
            fruitSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;

        }

        if (other.gameObject.name == "Red")
        {
            Fungus.Flowchart.BroadcastFungusMessage("NextFruit5");
            fruits.gameObject.GetComponent<Transform>().GetChild(9).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<Transform>().position = new Vector2(basket.gameObject.GetComponent<Transform>().position.x + offset2, basket.gameObject.GetComponent<Transform>().position.y);
            contadorFruta++;
            fruitSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;

        }
        if (other.gameObject.tag == "Basket" && contadorFruta == 5)
        {
            Fungus.Flowchart.BroadcastFungusMessage("Final");
            this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
            General.bloqPlayer = true;
            orange.gameObject.GetComponent<Transform>().SetParent(basket.gameObject.GetComponent<Transform>());
            yellow.gameObject.GetComponent<Transform>().SetParent(basket.gameObject.GetComponent<Transform>());
            blue.gameObject.GetComponent<Transform>().SetParent(basket.gameObject.GetComponent<Transform>());
            green.gameObject.GetComponent<Transform>().SetParent(basket.gameObject.GetComponent<Transform>());
            red.gameObject.GetComponent<Transform>().SetParent(basket.gameObject.GetComponent<Transform>());


        }


        if (other.gameObject.tag == "LimitR")
        {
            limitR = true;
        }

        if (other.gameObject.tag == "LimitL")
        {
            limitL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimitL")
        {
            limitL = false;
        }
        if (other.gameObject.tag == "LimitR")
        {
            limitR = false;
        }
    }
    public void CreateCat()
    {
        catClon = (GameObject)Instantiate(cat, catCreator.gameObject.GetComponent<Transform>().position, Quaternion.identity);
        catClon.gameObject.GetComponent<Animator>().SetTrigger("Jump");

    }
}
