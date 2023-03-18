//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{

    private GameObject[] PickUpsList = new GameObject[100];
    public GameObject[] Pickups;
    private int SpawnChance = 0;
    private int SpawnDistance = 30;
    private int SpawnCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCounter = 0;
        SpawnPickUpBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        PickUpsPlacer();
    }

    void SpawnPickUpBlocks()
    {
        for (int i = (int)transform.position.x - 500; i < 1000; i++)
        {
            SpawnChance = Random.Range(0,10);
            if (SpawnChance == Random.Range(0, 10))
            {
                print(SpawnCounter);
                PickUpsList[SpawnCounter] = Instantiate<GameObject>(Pickups[Random.Range(0, 2)], new Vector3(i + SpawnDistance, 5f, 0), transform.rotation);
                SpawnChance = -1;
                i += SpawnDistance;
                SpawnCounter++;
            }
            else
                i += (SpawnDistance - 10);
        }
    }
    void DestroyPickUps()
    {
        int TotalSpawn = SpawnCounter;
        for (int i = 0; i <= TotalSpawn; i++)
            if (PickUpsList[i] != null)
                Destroy(PickUpsList[i]);
    }

    void PickUpsPlacer()
    {
        if (DinoController.ShouldCreateAnewCourse == true)
        {
            SpawnCounter = 0;
            DestroyPickUps();
            SpawnPickUpBlocks();
            DinoController.ShouldCreateAnewCourse = false;
        }    
    }
}
