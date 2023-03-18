//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;

public class AmbienceManager : MonoBehaviour
{
    public Sound[] Clips;
    public AudioSource source;
   
   
    private void Start()
    {
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
            ChangeBackgroundAmbeince(0);
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
            ChangeBackgroundAmbeince(1);
        else if (BackgroundAndSpriteManager.currentLevelIndex == 3)
            ChangeBackgroundAmbeince(2);       
    }

    


    private void ChangeBackgroundAmbeince(int Index)
    {
        source.clip = Clips[Index].clip;
        source.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();
        source.loop = Clips[Index].loop;
        source.Play(); // after you have changed the audio clip and  its repsective audio attributes you need to always call the play function so to 
        // play the music
    }
    /*
    private void FadeIn(float MaxVolume)
    {
        if (source.volume <= MaxVolume)
            source.volume += 0.01f;    
    }

    private void FadeOut()
    {
        if (source.volume >= 0)
            source.volume -= 0.01f;
    }
    */
}



