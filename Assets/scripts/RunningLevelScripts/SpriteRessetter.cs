//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SpriteRessetter : MonoBehaviour
{
    public GameObject TeleportDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // this script will sit on the far mountains , the rocks and the sky and will reset there position based on the teleport location given 
    // for the sky and the farmountains it was fixed and the rocks a new location Gameobject  had to be created so that transitions was smooth
    // the ground textures didnt really needed the resets or the parallax effect so the textures were really copy pasted through out the level
    // some portions of the ground were set before and after the teleporter to show that there was ground before the reset
    void Update()
    {

        if (DinoController.ShouldCreateAnewCourse)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
            print("the sprite has been resetted!!!");
            print("the sprite name is:- " + transform.name);
            print("Teleported vectors:- " + transform.position.x);
            print("Teleporter Vectors:- " + TeleportDestination.transform.position.x);
        }
        if (DinoController.HasGameRestarted)
        {
            //transform.position = new Vector3(-10,transform.position.y,transform.position.z);
            print("the sprite has been resetted!!!");
            print("the sprite name is:- " + transform.name);
            print("Teleported vectors:- " + transform.position.x);
            print("Teleporter Vectors:- " + TeleportDestination.transform.position.x);
            DinoController.HasGameRestarted = false;
        }
    }
}
