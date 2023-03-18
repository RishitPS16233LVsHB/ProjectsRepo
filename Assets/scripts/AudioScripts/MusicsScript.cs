//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;
public class MusicsScript : MonoBehaviour
{
    public AudioSource source;
    public AudioSource AmbienceSource;
    public Sound[] Level1Music;
    public Sound[] Level2Music;
    public Sound[] Level3Music;
    
    public static int MusicIndex = 0;
    float timer = 0f;
    bool ChangeMusic = false;
    float PlayBackTimer = 0f;
    float Waitingtimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //print("loaded the music of system choice");

        ChangeMusic = true;
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
            source.clip = Level1Music[Random.Range(0,Level1Music.Length)].clip;
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
            source.clip = Level2Music[Random.Range(0,Level2Music.Length)].clip;
        else if (BackgroundAndSpriteManager.currentLevelIndex == 3)
            source.clip = Level3Music[Random.Range(0,Level3Music.Length)].clip;

        print("music index:- " + MusicIndex);
        print("music source clip :- " + source.clip);
        print("current level index:- " + BackgroundAndSpriteManager.currentLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {

        if (ChangeMusic)
        {
            MusicChanger();
            AmbienceSource.volume = SettingsVariable.GetMusicVolume();
        }
        if (source.clip == null)
            ChangeMusic = true;
        else
        {
            if (PlayBackTimer >= source.clip.length)
            {
                if (Waitingtimer >= 20f)
                {
                    IndexCheker();
                    ChangeMusic = true;
                    PlayBackTimer = 0f;
                    //timer = 0f;
                    source.clip = null;
                    Waitingtimer = 0f;
                }
                else
                {
                    AmbienceSource.volume = 0.7f;
                    Waitingtimer += Time.deltaTime;                    
                }
            }
            else
                PlayBackTimer = source.time;
        }
        
    }

    void MusicChanger()
    {            
           // print("checking the current level");
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
        {
            source.volume = 10f;
            PlayMusic(Level1Music, MusicIndex);
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
        {
            source.volume = 20f;
            PlayMusic(Level2Music, MusicIndex);
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 3)
        {
            source.volume = 20f;
            PlayMusic(Level3Music, MusicIndex);
        }
        //print("switching off the triggering variable");
        ChangeMusic = false;
        //print("checking index and increasing it");
        
        //print(" music index:- " + MusicIndex);
    }

    void IndexCheker()
    {
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
        {
            if (MusicIndex >= Level1Music.Length)
                MusicIndex = 0;
            else
                MusicIndex++;
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
        {
            if (MusicIndex >= Level2Music.Length)
                MusicIndex = 0;
            else
                MusicIndex++;
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 3)
        {
            if (MusicIndex >= Level3Music.Length)
                MusicIndex = 0;
            else
                MusicIndex++;
        }
    }


    void PlayMusic(Sound[] musics,int index)
    {
        source.clip = musics[index].clip;
        source.volume = SettingsVariable.GetMusicVolume();
        source.loop = false;
        source.Play();
    }
    /*
    void MusicFadeOut()
    {
        if (source.volume >= 0)
            source.volume -= 0.01f;
    }

    void MusicFadeIn()
    {
        if (source.volume <= 0.3f)
            source.volume += 0.01f;
    }
    */
}
