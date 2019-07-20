using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
 
    public string hand;

    void Update() {
 
    //Input, animation, whatever
 
    }
 
    void OnTriggerEnter2D(Collider2D col) {

        Debug.Log("Hit!");
 
        if (col.gameObject.tag == "Fruit")
        {
            if (hand.Equals("right"))
            {
                Debug.Log("Detected fruit by right hand");
            }
            else 
            {
                Debug.Log("Detected fruit by left hand");
            }
            
        }

    }
}
