using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    float LifeTimer = 0f;
    Vector3 TargetLocation;
    GameObject Player;
    private bool IsThirdLevel = false;
    public GameObject AnimatedChild;
    private float xMovement = 5f;

    public AudioClip Explode;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.volume = SettingsVariable.GetGeneralSoundsVolume();
            
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetXSpeed(float speed)
    {
        xMovement = speed;
    }
    // Update is called once per frame
    void Update()
    {

        source.volume = SettingsVariable.GetGeneralSoundsVolume();
        if (LifeTimer >= 3f)
        {
            //AnimatedChild.GetComponent<Animator>().SetBool("Hit",true);
            AnimatedChild.GetComponent<Animator>().Play("Explosion");
            xMovement = 0f;
            StartCoroutine(DestroyProjectile());
            StopCoroutine(DestroyProjectile());
        }
        else
            LifeTimer += Time.deltaTime;

        if(DinoController.startSuperSprint)
            Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<SphereCollider>(),true);
        else
            Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<SphereCollider>(), false);
        //AnimatedChild.GetComponent<Animator>().SetBool("Hit", false);
    }

    private void FixedUpdate()
    {
        if (DinoController.StopMovingObstacles == false)
        {
            if (IsThirdLevel) // this is homing missiles mother fucker dodge these ones
                GetComponent<Rigidbody>().MovePosition(transform.position + ((Player.transform.position - transform.position) * Time.deltaTime * 0.6f));
            else
                GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(xMovement, 0, 0) * Time.deltaTime * 10f));
        }
        else
        {
            Vector3 Jitter = new Vector3(Mathf.Sin(Time.time * 200f) * 100f,0,0);
            GetComponent<Rigidbody>().MovePosition(transform.position + (Jitter * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //AnimatedChild.GetComponent<Animator>().SetBool("Hit",true);
        
        if (collision.transform.GetComponent<Rigidbody>() != null)
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.right * 1f, ForceMode.Impulse);
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }
        xMovement = 0f;
        source.clip = Explode;
        if(!source.isPlaying)
            source.Play();
        AnimatedChild.GetComponent<Animator>().Play("Explosion");
        StartCoroutine(DestroyProjectile());
    }
    // my first ever coroutine experience what thing i have been doing wrong in the coroutine was that i was waiting at till the end of the executions
    // of the coroutine which make it wait no time instead i had to wait before some code section and then perform that code
    IEnumerator DestroyProjectile()
    {
        // waits for 3 seconds and destroys the current gameObject 
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);        
    }
}
