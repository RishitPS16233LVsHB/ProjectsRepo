//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody EnemyBody;
    Vector3 EnemyLocation;

    private float MovementSpeed;

    public GameObject AnimatedChild;
    public GameObject AnimatedChild2;
    public GameObject AnimatedChild3;

    public AudioSource BodySource;
    public AudioSource ScreamSource;

    public AudioClip Level2BodyClip;
    public AudioClip OtherLevelsBodyClip;

    public AudioClip Level2ScreamClip;
    public AudioClip OtherLevelsScreamClips;

    GameObject Player;
    
    // Start is called before the first frame update

    void Start()
    {
        BodySource.volume = SettingsVariable.GetGeneralSoundsVolume();
        
        MovementSpeed = 9f;
        //SettingsVariable.SetDifficultyLevel(3);
        //AdjustMovementAccordingToLevel();
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyBody = GetComponent<Rigidbody>();
    }
    /*
    void AdjustMovementAccordingToLevel()
    {
        if (SettingsVariable.GetDifficultyLevel() == 1)
            MovementSpeed = 9f;
        else if (SettingsVariable.GetDifficultyLevel() == 2)
            MovementSpeed = 15f;
        else if (SettingsVariable.GetDifficultyLevel() == 3)
            MovementSpeed = 24f;    
    }
    */

    // Update is called once per frame
    private void Update()
    {
        BodySource.volume = SettingsVariable.GetGeneralSoundsVolume();
        ChangeAnimations();
        if (transform.position.z > 0 || transform.position.z < 0)
            transform.position = new Vector3(transform.position.x,1.5f,0);
           
        if (EnemyLocation.x <= 0)
        {
            AnimatedChild.GetComponent<SpriteRenderer>().flipX = true;
            AnimatedChild2.GetComponent<SpriteRenderer>().flipX = true;
            AnimatedChild3.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            AnimatedChild.GetComponent<SpriteRenderer>().flipX = false;
            AnimatedChild2.GetComponent<SpriteRenderer>().flipX = false;
            AnimatedChild3.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void FixedUpdate()
    {
        RandomScream();
        if (DinoController.StopMovingObstacles == false)
            MoveEnemy();
        else
        {
            Vector3 Jitter = new Vector3(Mathf.Sin(Time.time * 200f) * 100f, 0, 0);
            GetComponent<Rigidbody>().MovePosition(transform.position + (Jitter * Time.deltaTime));
        }
    }

    void RandomScream()
    {
        int randomNumber = Random.Range(0, 100000);
        if (randomNumber >= 30 && randomNumber <= 100)
        {
            //print("you are lucky grandpa the zymer has decided to speak");
            if (!ScreamSource.isPlaying)
                if(!Player.GetComponent<DinoController>().GetGameOverFlag())
                    ScreamSource.Play();
        }
    }

    void MoveEnemy()
    {
        EnemyLocation = new Vector3(Mathf.Sin(Time.time), 0, 0);
        EnemyBody.MovePosition(transform.position + (EnemyLocation * MovementSpeed * Time.deltaTime));

        if (BackgroundAndSpriteManager.currentLevelIndex == 2)
        {
            BodySource.clip = Level2BodyClip;
            ScreamSource.clip = Level2ScreamClip;
            //BodySource.volume = 0.2f;
            BodySource.pitch = 3f;
        }
        else
        {
            ScreamSource.clip = OtherLevelsScreamClips;
            BodySource.clip = OtherLevelsBodyClip;
            //BodySource.volume = 1f;
            BodySource.pitch = 1f;
        }
        
        if(!BodySource.isPlaying)
            if(!Player.GetComponent<DinoController>().GetGameOverFlag())
                BodySource.Play();
    }
    void ChangeAnimations()
    {
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
        {
            AnimatedChild.GetComponent<SpriteRenderer>().enabled = true;
            AnimatedChild.GetComponent<Animator>().enabled = true;

            AnimatedChild2.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild2.GetComponent<Animator>().enabled = false;

            AnimatedChild3.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild3.GetComponent<Animator>().enabled = false;
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
        {
            AnimatedChild.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild.GetComponent<Animator>().enabled = false;

            AnimatedChild2.GetComponent<SpriteRenderer>().enabled = true;
            AnimatedChild2.GetComponent<Animator>().enabled = true;

            AnimatedChild3.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild3.GetComponent<Animator>().enabled = false;
        }
        else
        {
            AnimatedChild.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild.GetComponent<Animator>().enabled = false;

            AnimatedChild2.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild2.GetComponent<Animator>().enabled = false;

            AnimatedChild3.GetComponent<SpriteRenderer>().enabled = true;
            AnimatedChild3.GetComponent<Animator>().enabled = true;
        }
    }
}
