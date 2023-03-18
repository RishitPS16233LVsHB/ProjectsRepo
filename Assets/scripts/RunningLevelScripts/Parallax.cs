//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject MainCamera;
    private float length, startPosition,basePosition;
    public float ParallaxEffect;

    // this script is easy to understand if you are some what good at math which i ain't
    // but will try to explain what is going on
    // Start is called before the first frame update
    void Start()
    {
        // firstly we store the starting position of the sprite object when the damn game starts
        startPosition = transform.position.x;
        basePosition = startPosition;
        // then we store the total length of all sprites a object have using its sprite renderer component yes
        // the with the help of sprite renderer component the sprite length of the current object will be calculated 
        // on the basis of all the child and the parent sprite included pretty genius :)
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // the parallax effect is set for eack background component as sky has 1 ground has 0 effect or no parallax applied
        // the far mountaians and the rocks have the parallax of 0.75 and 0.5 based on there viewing distance 
        // the distance variable calculated how much camera has travelled from the initial start position
        // the temp variable keeps track of the like difference between the start and the main camera position i guess
        // as i said i suck at math 
        float temp = (MainCamera.transform.position.x * (1 - ParallaxEffect));
        float distance = MainCamera.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        // here we check what is the value of said temp variable is it greater than the startposition + length which means 
        // that the camera has travelled a full length of sprite's size and the sprite's x location must be incremented to the its length
        // in case of temp is less than the starting position - length which means the camera has moved a full length of sprite in backwards
        // so the sprite must move backwards by its length;
        // each times the sprite moves backwards and forwards the starting position is added or deduced then is assigned a new starting position 
        // so the check remains consistent
        if (temp > startPosition + length)
        {
            print("the sprite was moved forwards by the length size");
            startPosition += length;
            if (transform.name == "Rocks")
            {
                print("rocks x:- " + transform.position.x);
                print("the length:- " + length);
                print("BaseLocation :- " + basePosition);
                print("startPosition :- " + startPosition);
            }
        }
        else if (temp < startPosition - length)
            startPosition -= length;
        if (DinoController.HasGameRestarted)
        {
            startPosition = basePosition;
            transform.position = new Vector3(startPosition,transform.position.y,transform.position.z);
            DinoController.HasGameRestarted = false;
            print("sprite has been resetted");
            if(transform.name == "Rocks")
                print("the start position :- " + startPosition);
        }
        if (DinoController.ShouldCreateAnewCourse)
        {
            startPosition = basePosition;
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }


    }
}
