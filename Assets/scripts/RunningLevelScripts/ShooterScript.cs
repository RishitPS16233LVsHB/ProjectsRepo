//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;

public class ShooterScript : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject Dinosaur;
    public GameObject Launcher;
    public GameObject AnimatedChild;
    public GameObject AnimatedChild2;

    public AudioClip Fire;
    public AudioSource source;

    GameObject Player;
    public float ShootTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        source.volume = SettingsVariable.GetGeneralSoundsVolume();

        Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        source.volume = SettingsVariable.GetGeneralSoundsVolume();

        ChangeAnimations();
        Collider[] HitColliders = Physics.OverlapSphere(transform.position,20f); // checks for the player in the range of 20 units radius if he happens to be 
        // so in the range the turrets will fire right away
        foreach (Collider col in HitColliders)
        {
            if (col.transform.name == "dinosaur")
            {
                
                if (ShootTimer >= 0.35f && ShootTimer <= 0.69f)
                {
                    AnimatedChild.GetComponent<Animator>().SetBool("Fire", true);
                    AnimatedChild2.GetComponent<Animator>().SetBool("Fire", true);
                    source.clip = Fire;
                    if (!source.isPlaying)
                        if(!Player.GetComponent<DinoController>().GetGameOverFlag())
                            source.Play();
                    ShootTimer += Time.deltaTime;
                }
                else if (ShootTimer >= 0.69f)
                {
                    AnimatedChild.GetComponent<Animator>().SetBool("Fire", false);
                    AnimatedChild2.GetComponent<Animator>().SetBool("Fire", false);
                    Instantiate<GameObject>(Projectile, new Vector3(Launcher.transform.position.x, Launcher.transform.position.y, 0), Launcher.transform.rotation);
                    ShootTimer = 0f;
                }
                else
                {
                    AnimatedChild.GetComponent<Animator>().SetBool("Fire", false);
                    AnimatedChild2.GetComponent<Animator>().SetBool("Fire", false);
                    ShootTimer += Time.deltaTime;
                    //print("player encountered!!!");
                }
            }
        }               
    }
    void ChangeAnimations()
    {
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
        {
            AnimatedChild.GetComponent<Animator>().enabled = true;
            AnimatedChild.GetComponent<SpriteRenderer>().enabled = true;
            AnimatedChild2.GetComponent<Animator>().enabled = false;
            AnimatedChild2.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2 || BackgroundAndSpriteManager.currentLevelIndex == 3)
        {
            AnimatedChild.GetComponent<Animator>().enabled = false;
            AnimatedChild.GetComponent<SpriteRenderer>().enabled = false;
            AnimatedChild2.GetComponent<Animator>().enabled = true;
            AnimatedChild2.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
