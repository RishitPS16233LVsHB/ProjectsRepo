using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLevel3Script : MonoBehaviour
{
    Vector3 MovementVector;
    public GameObject AnimatedChild;
    public TextMeshProUGUI ControlsTab;
    public TextMeshProUGUI ObjectivesTab;

    public AudioClip GrassWalkingClip;
    public AudioSource BodySource;

    // Start is called before the first frame update
    void Start()
    {
        ControlsTab.color = new Color32(255, 255, 255, 255);
        ObjectivesTab.color = new Color32(255, 255, 255, 255);
        AnimatedChild.GetComponent<SpriteRenderer>().enabled = true;
        AnimatedChild.GetComponent<Animator>().enabled = true;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(6f);
        ControlsTab.color -= new Color32(0, 0, 0, 1);
        ObjectivesTab.color -= new Color32(0, 0, 0, 1);
    }
    void SetAudioVolume()
    {
        BodySource.volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    // Update is called once per frame
    void Update()
    {
        SetAudioVolume();
        if (ObjectivesTab.color.a > 0)
            StartCoroutine(WaitTime());

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            AnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            AnimatedChild.GetComponent<SpriteRenderer>().flipX = true;
            MovementVector = new Vector3(-1, 0, 0);
            PlayWalkingSounds();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PlayWalkingSounds();
            AnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            AnimatedChild.GetComponent<SpriteRenderer>().flipX = false;
            MovementVector = new Vector3(1, 0, 0);
        }
        else
        {
            if (BodySource.isPlaying)
                BodySource.Stop();
            AnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            MovementVector = new Vector3(0, 0, 0);
        }
        AnimatedChild.GetComponent<Animator>().speed = 0.7f;
    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + (MovementVector) * 0.08f);
    }

    private void PlayWalkingSounds()
    {
        if (!BodySource.isPlaying)
        {
            BodySource.clip = GrassWalkingClip;
            //BodySource.volume = 0.03f;
            BodySource.pitch = 1f;
            BodySource.Play();
        }    
    }
}
