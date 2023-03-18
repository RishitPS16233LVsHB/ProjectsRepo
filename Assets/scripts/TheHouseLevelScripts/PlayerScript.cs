//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
public class PlayerScript : MonoBehaviour
{
    public GameObject AnimatedChild;
    public AudioSource MeranFootSource;
    public AudioClip BareFootedWalkClip;
    public static bool isPauseMenuEnabled = false;

    // Start is called before the first frame update

    void SetAudioVolume()
    {
        MeranFootSource.volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    // Update is called once per frame
    void Update()
    {
        SetAudioVolume();
        if (!isPauseMenuEnabled) 
        { 
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {

                // move to the right code is here
                Vector3 Position = new Vector3(0.1f, 0, 0);
                GetComponent<Rigidbody>().MovePosition(transform.position - Position);
                AnimatedChild.GetComponent<SpriteRenderer>().flipX = true;
                AnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);

                PlayFootStepSounds();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {

                // move to the left code is here
                Vector3 Position = new Vector3(0.1f, 0, 0);
                GetComponent<Rigidbody>().MovePosition(transform.position + Position);
                AnimatedChild.GetComponent<SpriteRenderer>().flipX = false;
                AnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);

                PlayFootStepSounds();
            }
            else
            {
                if(MeranFootSource.isPlaying)
                    MeranFootSource.Stop();
                AnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            }
        }
    }

    private void PlayFootStepSounds()
    {
        if (!MeranFootSource.isPlaying)
        {
            MeranFootSource.clip = BareFootedWalkClip;
            MeranFootSource.volume = 0.2f;
            MeranFootSource.pitch = 1.7f;
            MeranFootSource.Play();
        }
    }
}
