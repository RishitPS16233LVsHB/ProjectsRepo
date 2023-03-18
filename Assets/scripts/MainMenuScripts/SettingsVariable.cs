//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

public class SettingsVariable 
{
    private static float GeneralSoundsVolume=0;
    private static float MusicVolume=0;
    private static float EnvironmentalAmbience=0;
    private static int DifficultyLevel=2;


    public static void SetGeneralSoundsVolume(float value) { GeneralSoundsVolume = value; }
    public static void SetMusicVolume(float value) { MusicVolume = value; }
    public static void SetEniviromentalAmbienceVolume(float value) { EnvironmentalAmbience = value; }
    public static void SetDifficultyLevel(int Level) { DifficultyLevel = Level; }

    public static float GetGeneralSoundsVolume() { return GeneralSoundsVolume; }
    public static float GetMusicVolume() { return MusicVolume; }
    public static float GetEnvironmentalAmbienceVolume() { return EnvironmentalAmbience; }
    public static int GetDifficultyLevel() { return DifficultyLevel; }
}
