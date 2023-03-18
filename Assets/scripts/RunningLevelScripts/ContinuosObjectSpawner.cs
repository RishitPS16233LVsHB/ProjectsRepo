//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ContinuosObjectSpawner : MonoBehaviour
{
    public GameObject[] ObstaclesAndEnemies;
    public GameObject Dinosaur;
    public GameObject Background;

    private int spawnChances = 0;
    private int SpawnDistance = 30;
    private int spawnCounter = 0;

    private GameObject[] ObstaclesList = new GameObject[100];
    // Start is called before the first frame update
    void Start()
    {
        //CreateBackground();
        CreateNewObstacleCourse(); // this we create a Obstacle Course for us in the Beginning
                                   // crucial as to make a new level and will be needy to create a new course out of it
    }

    // Update is called once per frame
    void Update()
    {
        CourseDecision(); // takes the decision of making a new course or not 
                          // it just makes a simple check if the dinosaur was teleported back to the source or not 
                          // if so make a new course 
    }

    // this method is rather simple but was tough for developing the logic
    void CreateNewObstacleCourse()
    {
        // after method call we will iterate through the size of the Spawnable Ground which is 0 to 1000
        for (int i = (int)transform.position.x - 500; i < 1000; i++)
        {
            // we randomly select a  number from 0 to 10 and then make a check with again A random Number from the sameRange
            spawnChances = Random.Range(0, 10);
            if (spawnChances == Random.Range(0, 10))
            {
                // if both matches then we instantiate an Object 
               // print("spawned a obstacle at:- " + i + SpawnDistance);
                // we instantiate the Object or Obstacle at the i+SpawnDistance
                ObstaclesList[spawnCounter] = Instantiate<GameObject>(ObstaclesAndEnemies[Random.Range(0,ObstaclesAndEnemies.Length)], new Vector3(i + SpawnDistance, 2f, 0), transform.rotation); // can store upto 100 spawned objects 
                // then quickly make the SpawnChance Value to ImPossible to Get Value so that no more than on Obstacle is Spawned at one place
                spawnChances = -1;
                // then after Spawning we know that the there is no new Spawning until the SpawnChance Variable matches with the Random number in the Conditional
                // so We Increment it with the Spawn distance so that adequate Spacing is Maintained and player can make jumps
                i += SpawnDistance;
                spawnCounter++;
                // we also increment the SpawnCounter which counts the Currently Spawned Object if they exceed by 5 then we increase the SpawnDistance and reset it
                // to 0 
            }
        }
    }

    public void DestroyCurrentObstacleCourse()
    {
        int totalSpawn = spawnCounter; 
        spawnCounter = 0; // this is set to 0 as to store new objects in the list
        for (int i = 0; i < totalSpawn; i++)
            Destroy(ObstaclesList[i]);
        spawnCounter = 0;
    }

    private void CourseDecision()
    {
        // this method makes a check whether the dinosaur has reached the end of the course or not by checking that it has been teleported or not if it is teleported
        // then a public static flag variable will be set of to alarm the Continuos Spawner to make a new course
        if (DinoController.ShouldCreateAnewCourse == true)
        {
            DestroyCurrentObstacleCourse(); // destroy the current course
            CreateNewObstacleCourse();      // creates a new course
            DinoController.ShouldCreateAnewCourse = false; // sets the flag variable to false so that no new courses be generated ever now and them
        }    
    }
    private void CreateBackground()
    {
        int i = (int)transform.position.x - 500;
        while(i < 1000)
        {
            Instantiate<GameObject>(Background,new Vector3(i,10,4),transform.rotation);
            i += 10;
        }
    }
}
