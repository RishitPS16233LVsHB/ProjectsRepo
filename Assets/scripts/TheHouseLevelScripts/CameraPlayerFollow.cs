//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this is a simple camera mover script very simple 
        // this script does one thing it checks if the players x coordinate if its less than zero then it moves the camera every 
        // update until the camera's x coordinate is near -7.5 units
        // if the player's coordinated were greater than 0 then  camera moves every update until the camera's x coordinate is near to 8 units
        if (Player.transform.position.x < 0)
        {
            if(transform.position.x > -7.5f)
                transform.position -= new Vector3(0.2f, 0, 0);
        }
        else if (Player.transform.position.x > 0)
        {
            if(transform.position.x < 8f)
                transform.position += new Vector3(0.2f, 0, 0);        
        }
    }
}
