//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    BoxCollider Bxc;
    // Start is called before the first frame update
    void Start()
    {
        Bxc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DinoController.startSuperSprint)        
            Bxc.enabled = false;        
        else
            Bxc.enabled = true;
    }
}
