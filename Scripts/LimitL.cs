using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Clouds")
        {
            Destroy(other.gameObject);
            General.isCloud = !General.isCloud;
           
        }
    }
}
