//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{

    private static AudioClip ClickSound;
    private static GameObject ClickSource;
    //private int Count = 0;

    void SetAudioVolume()
    {
        ClickSource.GetComponent<AudioSource>().volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    // Start is called before the first frame update
    void Start()
    {
        // got the source
        if (ClickSource == null)
        {
            ClickSource = new GameObject();
            //ClickSource.name = "name" + Count;
            //print(Count);
            ClickSource.AddComponent<AudioSource>();
            SetAudioVolume();
        }
        // got the clip 
        ClickSound = Resources.Load<AudioClip>("UISounds/ButtonClick");
        ClickSource.GetComponent<AudioSource>().clip = ClickSound;

        if (gameObject.GetComponent<Button>() != null)
            gameObject.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(DoClickSound));        

    }

    
    void DoClickSound()
    {
        SetAudioVolume();
        if(!ClickSource.GetComponent<AudioSource>().isPlaying)
            ClickSource.GetComponent<AudioSource>().Play();        
    }
}
