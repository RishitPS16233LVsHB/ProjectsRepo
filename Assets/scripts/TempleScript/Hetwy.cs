//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hetwy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool startTempleSequence = false;
    public GameObject Player;
    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        SphereCheck();
    }

    void SphereCheck()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position,5f);
        foreach (Collider col in colls)
        {
            if (col.gameObject == Player)
            {
                TempleSequence.StartTheSequence = true;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("isMoving", false);
                Player.GetComponent<PlayerLevel3Script>().enabled = false;        
            }
        }
    }
}
