//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectController : MonoBehaviour
{
    GameObject Dino;
    // Start is called before the first frame update
    void Start()
    {
        Dino = GameObject.FindGameObjectWithTag("Player"); // finds a gameObject of tag with player attached to it 
        
    }

    // Update is called once per frame
    void Update()
    {
        // with the help of the physics class we can avoid the collision
        // with the GameObject with Tag Player and current GameObject 
        if (DinoController.startSuperSprint)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
        }    
    }


}

