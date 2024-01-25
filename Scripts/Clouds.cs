using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject clouds;
    private GameObject cloudsClone;
    public GameObject limitR;
    public GameObject limitL;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!General.isCloud)
        {
            cloudsClone = (GameObject)Instantiate(clouds, limitR.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            General.isCloud = true; ;
        }
    }
   
}
