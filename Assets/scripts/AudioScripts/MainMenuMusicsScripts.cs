//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicsScripts : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] MainMenuTheme;
    float MusicPlayBackTimer = 0f;
    int ThemeIndex = 0;
    static int PreviousIndex = 0;
    float waitingTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = MainMenuTheme[Random.Range(0,MainMenuTheme.Length - 1)];
        source.volume = 0.7f;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTheme();
    }


    void ChangeTheme()
    {
        if (MusicPlayBackTimer >= source.clip.length)
        {
            print("the song is over time to load a new song");

            if (waitingTimer >= 3f)
            {
                PreviousIndex = ThemeIndex;
                ThemeIndex = Random.Range(0,MainMenuTheme.Length - 1);

                if (PreviousIndex == ThemeIndex)
                    ThemeIndex = 4;
                //ThemeIndex++;
                //if (ThemeIndex >= MainMenuTheme.Length)
                //    ThemeIndex = 0;
                
                source.clip = MainMenuTheme[ThemeIndex];
                source.Play();
                waitingTimer = 0f;
                MusicPlayBackTimer = 0f;
            }
            else
                waitingTimer += Time.deltaTime;            
        }
        else
        {
            MusicPlayBackTimer = source.time;        
        }        
    }
}
