//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    public static bool StartedArmourEffect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hover();

    }

    void Hover()
    {
        float Ylocation = Mathf.Sin(Time.time) * 3; // waves over and over using the sine function at a frequency 3hertz
        transform.Translate(new Vector3(0,Ylocation * 0.4f * Time.deltaTime ,0)); // translates the yLocation of the transform or the pickup object        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "dinosaur")
        {
            if (transform.name == "armourPickup")
            {
                // the current object is a armour pick up so the effects of the armour must be enabled to the player
                DinoController.ArmourPickedUp = true;
                StartedArmourEffect = true;
            }
            else if (transform.name == "HealthPickup")
            {
                // the current object is a health Pick up so the effects of the health pick up must be enabled on the player
                DinoController.HealthPickedUp = true;
            }
            // then destroy the pick up object so to not check again 
            Destroy(transform.gameObject);
        }
    }
}
