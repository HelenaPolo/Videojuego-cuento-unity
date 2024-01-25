using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

   // private float horizontal;
    //private float speed;

    // Start is called before the first frame update
    void Start()
    {
      //  speed = 3.0f;
        //horizontal = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimitGR")
        {
            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                this.gameObject.GetComponent<Transform>().Translate(0.0f, 0.0f, 0.0f);
            }

        }
        if (other.gameObject.tag == "LimitGL")
        {
            if (Input.GetAxis("Horizontal") < 0.0f)
            {
                this.gameObject.GetComponent<Transform>().Translate(0.0f, 0.0f, 0.0f);
            }

        }
        Debug.Log("limitGround");
    }
}
